using System.Collections.Generic;
using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class BirthEvent : Event
    {
        public override ActionType ActionType => ActionType.GivingBirth;
        public List<int> ChildrenId { get; set; }
        public int StepNumber { get; set; }
        public override string GetDescription()
        {
            var description = $"{ActorType.Name}({ActorId}) gave birth.";
            return description;
        }
    }
}
