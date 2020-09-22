using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class PregnancyProgressionEvent : Event
    {
        public override ActionType ActionType => ActionType.ProgressPregnancy;
        public int StepNumber { get; set; }
        public override string GetDescription()
        {
            var description = $"{ActorType.Name}({ActorId}) progressed pregnancy.";
            return description;
        }
    }
}
