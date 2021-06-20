using System;
using System.Collections.Generic;
using System.Linq;
using Life.Core.GameObjects;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Life.DAL.EventSavers;
using Life.DAL.Models;
using Life.DAL.Repositories;
using GameTile = Life.DAL.Models.GameTile;

namespace Life.DAL
{
    public class DatabaseEventRecordingProvider : IEventRecordingProvider
    {
        private static List<Type> _eventSaverTypes;
        private readonly IServiceProvider _serviceProvider;
        private List<EventSaver> _eventSavers;
        private readonly GameTilesRepo _gameTilesRepo;
        private readonly GOStepStartStateRepo _goStepStartStateRepo;
        private List<EventSaver> EventSavers => _eventSavers ??= GetEventSavers();
        public static List<Type> EventSaverTypes => _eventSaverTypes ??= GetEventSaverTypes();
        public static Guid GameSessionId { get; set; }
        public static Guid StepId { get; set; }
        public DatabaseEventRecordingProvider(IServiceProvider serviceProvider, 
            GameTilesRepo gameTilesRepo, GOStepStartStateRepo goStepStartStateRepo)
        {
            _serviceProvider = serviceProvider;
            _gameTilesRepo = gameTilesRepo;
            _goStepStartStateRepo = goStepStartStateRepo;
        }
        public void RecordEvent(IEvent eventObj)
        {
            var saver = EventSavers.Find(x => x.SaveableEventType == eventObj.GetType());
            if (saver !=null)
            {
                saver.Save(eventObj);
            }
            else
            {
                throw new ArgumentOutOfRangeException(eventObj.ToString(),"No event saver found for specified event");
            }
        }

        public void UpdateGameSessionState(IGameSessionState state, int stepNumber)
        {
            FillGameTilesData(state.Map.Tiles);
            FillGameObjectsStepStateData(state.Map.GameObjects);
        }

        private List<EventSaver> GetEventSavers() => EventSaverTypes.Select(type => (EventSaver) _serviceProvider.GetService(type)).ToList();

        private static List<Type> GetEventSaverTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsSubclassOf(typeof(EventSaver)) && !x.IsAbstract)
                .ToList();
        }
        private void FillGameTilesData(List<Core.MapObjects.GameTileDto> tiles)
        {
            List<GameTile> items = new List<GameTile>();
            var stepId = StepId;
            foreach (var tile in tiles)
            {
                items.Add(new GameTile
                {
                    StepId = stepId,
                    AreaType = (int)tile.AreaType,
                    X = tile.Coordinates.X,
                    Y = tile.Coordinates.Y
                });
            }
            _gameTilesRepo.Create(items);
        }
        private void FillGameObjectsStepStateData(List<GameObject> gameObjects)
        {
            List<GoStepStartState> items = new List<GoStepStartState>();
            var stepId = StepId;
            foreach (var gameObject in gameObjects)
            {
                var objects = new List<GameObject> { gameObject };
                var dataHolder = new GoStepStartState
                {
                    GameObjectId = gameObject.Id,
                    StepId = stepId,
                    X = gameObject.Coordinates.X,
                    Y = gameObject.Coordinates.Y,
                    Hp = gameObject.Hp,
                    Status = (int)gameObject.Status,
                };
                if (objects.OfType<IGrowable>().Any())
                {
                    var growable = objects.OfType<IGrowable>().Single();
                    dataHolder.CurrentAge = growable.CurrentAge;
                }
                if (objects.OfType<IGender>().Any())
                {
                    var genderObj = objects.OfType<IGender>().Single();
                    dataHolder.GenderType = (int)genderObj.GenderType;
                    dataHolder.CurrentPregnancyTime = genderObj.CurrentPregnancyTime;
                }
                items.Add(dataHolder);
            }
            _goStepStartStateRepo.Create(items);
        }
    }
}
