using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class GettingPregnantEvent : Event
    {
        public override ActionType ActionType => ActionType.GetPregnant;
        public int StepNumber { get; set; }
        public override string GetDescription()
        {
            var description = $"{ActorType.Name}({ActorId}) got pregnant.";
            return description;
        }
    }
}
