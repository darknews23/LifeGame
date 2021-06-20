using System;
using System.Collections.Generic;
using System.Linq;
using Life.Core.GameObjects;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.MapObjects
{
    public class Map : IMap
    {
        public Coordinates WorldDimensions { get; set; }
        public List<GameTileDto> Tiles { get; }
        public List<BaseGameObject> GameObjects { get; }
        private Dictionary<AreaType, List<Coordinates>> _areaTypeCoordinates;

        public Dictionary<AreaType, List<Coordinates>> AreaTypeCoordinates
        {
            get
            {
                if (!_areaTypeCoordinates.Any())
                {
                    _areaTypeCoordinates = GetAreaTypeCoordinates();
                }
                return _areaTypeCoordinates;
            }
        }

        public Map()
        {
            Tiles = new List<GameTileDto>();
            GameObjects = new List<BaseGameObject>();
            _areaTypeCoordinates = new Dictionary<AreaType, List<Coordinates>>(Enum.GetNames(typeof(AreaType)).Length);
        }

        public void UpdateGameObjectsAndTiles()
        {
            
            var deadObjects = GameObjects.Where(gameObject => gameObject == null).ToList();
            foreach (var gameObject in deadObjects)
            {
               GameObjects.Remove(gameObject);
            }
            foreach (var tile in Tiles)
            {
                tile.GameObjectsOnTile.Clear();
                tile.GameObjectsOnTile.AddRange(GameObjects.Where(x => x.Coordinates.Equals(tile.Coordinates)));
            }
        }
        
        private Dictionary<AreaType, List<Coordinates>> GetAreaTypeCoordinates()
        {
            var areaTypeCoordinates = new Dictionary<AreaType, List<Coordinates>>();
            for (int i = 0; i < Enum.GetNames(typeof(AreaType)).Length; i++)
            {
                List<Coordinates> coordinates = Tiles
                    .Where(x => x.AreaType == (AreaType)i)
                    .Select(x => x.Coordinates)
                    .ToList();
                areaTypeCoordinates.Add((AreaType)i, coordinates);
            }
            return areaTypeCoordinates;
        }
    }
}
