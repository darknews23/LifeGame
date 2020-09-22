using System.Collections.Generic;
using Life.Core.GameObjects;
using Life.Core.MapObjects;
using Life.Core.Parameters;

namespace Life.Core.Events
{
     public class NewStepEvent : Event
     {
         public override ActionType ActionType => ActionType.NewStep;
        public int StepNumber { get; set; }
        public List<GameTile> Tiles { get; set; }
        public List<GameObject> GameObjects { get; set; }
        public override string GetDescription()
        {
            var description =  $"Step {StepNumber}";
            return description;
        }
    }
}
