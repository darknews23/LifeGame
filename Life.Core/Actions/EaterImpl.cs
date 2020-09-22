using System.Linq;
using System.Text;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Microsoft.Extensions.Logging;

namespace Life.Core.Actions
{
    public class EaterImpl : Actions, IEater
    {
        private readonly EatingEvent _eatingEvent;
        private readonly IEventRecorder _eventRecorder;
        public IEater EaterOwner { get; set; }
        public Coordinates Coordinates { get; set; }
        public int Id { get; }
        public IMap Map { get; }
        public int Hp { get; set; }
        private readonly ILogger _logger;
        private readonly StringBuilder _stringBuilder;

        public EaterImpl(ILoggerFactory loggerFactory, EatingEvent eatingEvent, IEventRecorder recorder)
        {
            _logger = loggerFactory.CreateLogger<EaterImpl>();
            _stringBuilder = new StringBuilder();
            _eatingEvent = eatingEvent;
            _eventRecorder = recorder;
        }

        public void Eat()
        {
            _stringBuilder.Clear();
            var eatableObjects= EaterOwner.Map.Tiles
                .First(x => x.Coordinates.Equals(EaterOwner.Coordinates))
                .GameObjectsOnTile
                .Where(x =>
                    x.GetType() != EaterOwner.GetType())
                .OfType<IEatable>()
                .ToList();

            if (eatableObjects.Count > 0)
            {
                int index = GameSession.Random.Next(0, eatableObjects.Count);
                _stringBuilder.Append(
                    $"{EaterOwner.GetType().Name}({EaterOwner.Id}) ate {eatableObjects[index].GetType().Name}({eatableObjects[index].Id}). " +
                    $"{EaterOwner.GetType().Name}({EaterOwner.Id}) Hp: {EaterOwner.Hp} -> ");

                _eatingEvent.VictimId = eatableObjects[index].Id;
                _eatingEvent.VictimType = eatableObjects[index].GetType();
                var hpChange = eatableObjects[index].GetEaten();
                EaterOwner.Hp += hpChange;

                _stringBuilder.Append($"{EaterOwner.Hp}\n");

                _eatingEvent.ActorId = EaterOwner.Id;
                _eatingEvent.ActorType = EaterOwner.GetType();
                _eatingEvent.HpChange = hpChange;
                _eatingEvent.StepNumber = GameSession.StepCount;

                _eventRecorder.Record(_eatingEvent);

                _logger.LogInformation(_stringBuilder.ToString());
            }
        }
    }
}
