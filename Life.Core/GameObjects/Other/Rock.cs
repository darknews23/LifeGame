using System.Collections.Generic;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.GameObjects.Other
{
    class Rock : GameObject, IObstacle
    {
        public override List<AreaType> Habitat => new List<AreaType>()
        {
            AreaType.Land,
            AreaType.Water
        };
        public Rock(IMap map, DeathEvent deathEvent, IEventRecorder eventRecorder) : base(map, deathEvent, eventRecorder)
        {
            Hp = 500;
        }
    }
}
