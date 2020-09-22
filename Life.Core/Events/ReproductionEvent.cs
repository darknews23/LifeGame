using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class ReproductionEvent : Event
    {
        public override ActionType ActionType => ActionType.InitiateReproduction;

        public int FemaleId { get; set; }
        public int StepNumber { get; set; }
        public override string GetDescription()
        {
            var description = $"{ActorType.Name}({ActorId}) initiated reproduction with {ActorType.Name}({FemaleId}).";
            return description;
        }
    }
}
