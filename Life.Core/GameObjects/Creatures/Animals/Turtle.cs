using System.Collections.Generic;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.GameObjects.Creatures.Animals
{
    class Turtle : Animal
    {
        public override int BirthTime => 2;
        public override int MaxBirth => 3;
        public override int AdultAge => 3;
        public override Dictionary<MoveType, int> AllowedMoveTypes => new Dictionary<MoveType, int>
        {
            {MoveType.Walk, 2},
            {MoveType.Swim, 3}
        };
        public override List<AreaType> Habitat => new List<AreaType>
        {
            AreaType.Land,
            AreaType.Water
        };

        public Turtle(IMap map, IGrowable growable, IMovable movable, IEater eater, IGender gender,
            DeathEvent deathEvent, IEventRecorder eventRecorder)
            : base(map, growable, movable, eater, gender, deathEvent, eventRecorder)
        {
            Hp = 10;
        }
    }
}
