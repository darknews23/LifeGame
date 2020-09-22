using System;
using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class EatingEvent : HpChangeEvent
    {
        public override ActionType ActionType => ActionType.Eating;
        public int VictimId { get; set; }
        public Type VictimType { get; set; }
        public int StepNumber { get; set; }
        public override string GetDescription()
        {
            var description = $"{ActorType.Name}({ActorId}) ate {VictimType.Name}({VictimId}). Hp change +{HpChange}.";
            return description;
        }
    }
}
