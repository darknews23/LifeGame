using System;
using System.Collections.Generic;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.MapObjects
{
    public class MapGenerator : IGenerator
    {
        private IMap Map { get; }
        private readonly List<int> _areaTypeCounts = new List<int>(Enum.GetNames(typeof(AreaType)).Length);
        private readonly MapGenerationEvent _mapGenerationEvent;
        private readonly IEventRecorder _eventRecorder;

        public MapGenerator(IMap map, MapGenerationEvent mapGenerationEvent, IEventRecorder eventRecorder)
        {
            Map = map;
            _mapGenerationEvent = mapGenerationEvent;
            _eventRecorder = eventRecorder;
        }
        public void Generate()
        {
            //Как появится конфиг, можно будет брать значения из него
            int totalTilesCount = Map.WorldDimensions.X * Map.WorldDimensions.Y;
            int tilesLeft = totalTilesCount;
            for (int i = 0; i < _areaTypeCounts.Capacity-1; i++)
            {
                _areaTypeCounts.Add(totalTilesCount / _areaTypeCounts.Capacity);
                tilesLeft -= _areaTypeCounts[i];
            }
            _areaTypeCounts.Add(tilesLeft);

            for (var i = 1; i < Map.WorldDimensions.X + 1; i++)
            {
                for (var j = 1; j < Map.WorldDimensions.Y + 1; j++)
                {
                    while (true)
                    {
                        var randomAreaTypeIndex = GameSession.Random.Next(0, Enum.GetNames(typeof(AreaType)).Length);
                        if (_areaTypeCounts[randomAreaTypeIndex] > 0)
                        {
                            Map.Tiles.Add(new GameTileDto((AreaType)randomAreaTypeIndex, new Coordinates(i, j)));
                            _areaTypeCounts[randomAreaTypeIndex]--;
                            break;
                        }
                    }
                }
            }
            _mapGenerationEvent.Tiles = Map.Tiles;
            _mapGenerationEvent.StepNumber = GameSession.StepCount;
            _eventRecorder.Record(_mapGenerationEvent);
        }
    }
}
