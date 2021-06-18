using System;
using System.Collections.Generic;
using System.IO;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    class MapGenerationSaver : StepEventSaver
    {
        private readonly GameTilesRepo _gameTilesRepo;
        public override Type SaveableEventType => typeof(MapGenerationEvent);
        
        public MapGenerationSaver(LifeGameDbContext context, StepsRepo stepsRepo, GameTilesRepo gameTilesRepo)
            : base(context, stepsRepo)
        {
            _gameTilesRepo = gameTilesRepo;
        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is MapGenerationEvent ev)
            {
                var stepId = DatabaseEventRecordingProvider.StepId;
                List<GameTiles> items = new List<GameTiles>();
                foreach (var tile in ev.Tiles)
                {
                    items.Add(new GameTiles
                    {
                        StepId = stepId,
                        X = tile.Coordinates.X,
                        Y = tile.Coordinates.Y,
                        AreaTypeId = (int)tile.AreaType
                    });
                }

                _gameTilesRepo.Create(items);
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
        }

    }
}