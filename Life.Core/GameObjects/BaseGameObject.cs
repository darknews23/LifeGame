using System.Collections.Generic;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Life.Core.Parameters;

namespace Life.Core.GameObjects
{
    public abstract class BaseGameObject : ICoordinate, IIdentification, IHabitant
    {
        private int _hp;
        private Coordinates _coordinates;
        private readonly DeathEvent _deathEvent;
        private readonly IEventRecorder _eventRecorder;
        public int Id { get; }
        public abstract List<AreaType> Habitat { get; }
        public IMap Map { get; }
        public Status Status { get; set; }
        public Coordinates Coordinates
        {
            get => _coordinates ??= GetRandomCoordinates();
            set => _coordinates = value;
        }
        public int Hp
        {
            get => _hp;
            set
            {
                _hp = value;
                if (_hp <= 0)
                {
                    Die();
                }
            }
        }

        protected BaseGameObject(IMap map, DeathEvent deathEvent, IEventRecorder eventRecorder)
        {
            Id = GameSession.GetGameObjectId;
            _deathEvent = deathEvent;
            _eventRecorder = eventRecorder;
            Map = map;
            Status = Status.Child;
        }

        private Coordinates GetRandomCoordinates()
        {
            var randomHabitatIndex = GameSession.Random.Next(0,Habitat.Count);
            var randomCoordinatesIndex = GameSession.Random.Next(0, Map.AreaTypeCoordinates[Habitat[randomHabitatIndex]].Count); 
            return Map.AreaTypeCoordinates[Habitat[randomHabitatIndex]][randomCoordinatesIndex];
        }
        private void Die()
        {
            var index = Map.GameObjects.FindIndex(x => x?.Id == Id);
            if (index != -1)
            {
                _deathEvent.ActorType = this.GetType();
                _deathEvent.ActorId = Id;
                _eventRecorder.Record(_deathEvent);
                Map.GameObjects[index] = null;
            }
        }
    }
}
