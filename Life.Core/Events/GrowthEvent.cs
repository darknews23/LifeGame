using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class GrowthEvent : HpChangeEvent
    {
        public override ActionType ActionType => ActionType.Grow;
        public bool BecameAdult { get; set; }
        public int StepNumber { get; set; }
        public override string GetDescription()
        {
            var description1 = $"{ActorType.Name}({ActorId}) grew. Hp change +{HpChange}. ";
            var description2 = BecameAdult ? "Became adult" : "";
            return $"{description1} {description2}";
        }
    }
}
