using System.Collections.Generic;
using Life.Core.GameObjects;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.MapObjects
{
    public class GameTileDto : ICoordinate
    {
        public AreaType AreaType { get; }
        public Coordinates Coordinates { get; set; }
        public List<BaseGameObject> GameObjectsOnTile { get; set; }
        public GameTileDto(AreaType areaType, Coordinates coordinates, List<BaseGameObject> gameObjectsOnTile = null)
        {
            AreaType = areaType;
            Coordinates = coordinates;
            GameObjectsOnTile = new List<BaseGameObject>();
            if (gameObjectsOnTile != null)
            {
                GameObjectsOnTile.AddRange(gameObjectsOnTile);
            }
        }
    }
}
