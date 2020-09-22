using System.Collections.Generic;
using Life.Core.GameObjects;
using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class GameObjectsCreationEvent : Event
    {
        public override ActionType ActionType => ActionType.GameObjectsCreation;
        public List<GameObject> GameObjects { get; set; }
        public int StepNumber { get; set; }
        public override string GetDescription()
        {
            return "GameObjects created.";
        }
    }
}