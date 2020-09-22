using System;
using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class MovementEvent : Event
    {
        public override ActionType ActionType => ActionType.Move;
        public Direction Direction { get; set; }
        public int Distance { get; set; }
        public MoveType MoveType { get; set; }
        public int StepNumber { get; set; }
        public override string GetDescription()
        {
            var description = $"{ActorType.Name}({ActorId}) moved " +
                              $"{Enum.GetName(Direction.GetType(), Direction)} {Distance} tiles " +
                              $"using {Enum.GetName(MoveType.GetType(), MoveType)}.";
            return description;
        }
    }
}
