using System.Collections.Generic;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.GameObjects.Creatures.Animals
{
    class Sparrow : Animal
    {
        public override int BirthTime => 3;
        public override int MaxBirth => 3;
        public override int AdultAge => 2;
        public override Dictionary<MoveType, int> AllowedMoveTypes => new Dictionary<MoveType, int>
        {
            {MoveType.Walk, 2},
            {MoveType.Fly,3}
        };
        public override List<AreaType> Habitat => new List<AreaType>
        {
            AreaType.Land
        };

        public Sparrow(IMap map, IGrowable growable, IMovable movable, IEater eater, IGender gender,
            DeathEvent deathEvent, IEventRecorder eventRecorder)
            : base(map, growable, movable, eater, gender, deathEvent, eventRecorder)
        {
            Hp = 10;
        }
    }
}
