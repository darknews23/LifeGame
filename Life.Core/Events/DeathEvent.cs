using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class DeathEvent : Event
    {
        public override ActionType ActionType => ActionType.Death;
        public int StepNumber { get; set; }

        public override string GetDescription()
        {
            return $"{ActorType.Name}({ActorId}) died";
        }
    }
}
