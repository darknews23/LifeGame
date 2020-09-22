using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.GameObjects.Creatures
{
    abstract class Plant : Creature, IEatable
    {
        private readonly IEatable _eatable;
        public override int AdultAge => 5;
        public IEatable EatableOwner { get; set; }
        public abstract int BeingEatenDamage { get; }
        public abstract bool IsFullyEatable { get; }
        public override bool IsEverGrowing => true;

        protected Plant(IMap map, IGrowable growable, IEatable eatable, DeathEvent deathEvent, IEventRecorder eventRecorder) 
            : base(map, growable, deathEvent, eventRecorder)
        {
            Status = Status.Child;
            _eatable = eatable;
            _eatable.EatableOwner = this;
        }

        public int GetEaten()
        {
            return _eatable.GetEaten();
        }
    }
}
