using System.Collections.Generic;
using Life.Core.GameObjects;
using Life.Core.MapObjects;
using Life.Core.Parameters;

namespace Life.Core.Interfaces
{
    public interface IMap
    {
        Coordinates WorldDimensions { get; set; }
        List<BaseGameObject> GameObjects { get; }
        List<GameTileDto> Tiles { get; }
        Dictionary<AreaType, List<Coordinates>> AreaTypeCoordinates { get; }
        void UpdateGameObjectsAndTiles();
    }
}
