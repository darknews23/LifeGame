using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class BeingEatenEvent : HpChangeEvent
    {
        public override ActionType ActionType => ActionType.BeingEaten;
        public int StepNumber { get; set; }
        public override string GetDescription()
        {
            var description = $"{ActorType.Name}({ActorId}) got eaten. Hp change -{HpChange}.";
            return description;
        }
    }
}
