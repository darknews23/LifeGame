using System.Collections.Generic;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.GameObjects.Creatures.Animals
{
    class Fish : Animal, IEatable
    {
        private readonly IEatable _eatable;
        public int BeingEatenDamage => Hp;
        public bool IsFullyEatable => true;
        public override int BirthTime => 2;
        public override int MaxBirth => 5;
        public override int AdultAge => 3;
        public override Dictionary<MoveType, int> AllowedMoveTypes => new Dictionary<MoveType, int>
        {
            {MoveType.Swim, 4}
        };
        public override List<AreaType> Habitat => new List<AreaType>
        {
            AreaType.Water
        };
        public IEatable EatableOwner { get; set; }
        public Fish(IMap map, IGrowable growable, IMovable movable, IEater eater, IEatable eatable, IGender gender,
            DeathEvent deathEvent, IEventRecorder eventRecorder)
            : base(map, growable, movable, eater, gender, deathEvent, eventRecorder)
        {
            Hp = 10;
            _eatable = eatable;
            _eatable.EatableOwner = this;
        }

        public int GetEaten()
        {
            return _eatable.GetEaten();
        }
    }
}
