using System.Collections.Generic;
using Life.Core.GameObjects;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.MapObjects
{
    public class GameTile : ICoordinate
    {
        public AreaType AreaType { get; }
        public Coordinates Coordinates { get; set; }
        public List<GameObject> GameObjectsOnTile { get; set; }
        public GameTile(AreaType areaType, Coordinates coordinates, List<GameObject> gameObjectsOnTile = null)
        {
            AreaType = areaType;
            Coordinates = coordinates;
            GameObjectsOnTile = new List<GameObject>();
            if (gameObjectsOnTile != null)
            {
                GameObjectsOnTile.AddRange(gameObjectsOnTile);
            }
        }
    }
}
