using System.Collections.Generic;
using Life.Core.MapObjects;
using Life.Core.Parameters;

namespace Life.Core.Events
{
    public class MapGenerationEvent : Event
    {
        public override ActionType ActionType => ActionType.MapGeneration;
        public List<GameTileDto> Tiles { get; set; }
        public int StepNumber { get; set; }
        public override string GetDescription()
        {
            return "Map generated.";
        }
    }
}