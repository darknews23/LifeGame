using Life.Core.Events;
using Life.Core.Interfaces;

namespace Life.Core.GameObjects
{
    public abstract class Creature : BaseGameObject, IGrowable
    {
        private readonly IGrowable _growable;

        public int CurrentAge { get; set; }
        public abstract bool IsEverGrowing { get; }
        public abstract int AdultAge { get; }

        public IGrowable GrowableOwner { get; set; }

        protected Creature(IMap map, IGrowable growable, DeathEvent deathEvent, IEventRecorder eventRecorder) : base(map, deathEvent, eventRecorder)
        {
            CurrentAge = 0;
            _growable = growable;
            _growable.GrowableOwner = this;
        }

        public void Grow()
        {
            _growable?.Grow();
        }
    }
}
