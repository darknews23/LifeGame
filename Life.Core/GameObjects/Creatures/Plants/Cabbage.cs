using System.Collections.Generic;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.GameObjects.Creatures.Plants
{
    class Cabbage : Plant
    {
        public override int BeingEatenDamage => Hp;
        public override bool IsFullyEatable => true;
        public override List<AreaType> Habitat => new List<AreaType>
        {
            AreaType.Land
        };
        public Cabbage(IMap map, IGrowable growable, IEatable eatable, DeathEvent deathEvent, IEventRecorder eventRecorder) 
            : base(map, growable, eatable, deathEvent, eventRecorder)
        {
            Hp = 200;
        }
    }
}
