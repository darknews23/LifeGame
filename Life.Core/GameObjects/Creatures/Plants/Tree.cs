using System.Collections.Generic;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.GameObjects.Creatures.Plants
{
    class Tree : Plant, IObstacle
    {
        public override int BeingEatenDamage => 10;
        public override bool IsFullyEatable => false;
        public override List<AreaType> Habitat => new List<AreaType>
        {
            AreaType.Land
        };
        public Tree(IMap map, IGrowable growable, IEatable eatable, DeathEvent deathEvent, IEventRecorder eventRecorder) 
            : base(map, growable, eatable, deathEvent, eventRecorder)
        {
            Hp = 500;
        }
    }
}
