using System;
using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class NewGameSessionEvent : Event
    {
        public override ActionType ActionType => ActionType.NewSession;
        public DateTime Created { get; set; } 
        public NewGameSessionEvent()
        {
            Created = DateTime.Now;
        }
        public override string GetDescription()
        {
            var description =  $"New Game Started at {Created}";
            return description;
        }
    }
}
