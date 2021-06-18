using System;
using System.Collections.Generic;
using System.Linq;
using Life.Core.GameObjects;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Life.DAL.EventSavers;
using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL
{
    public class DatabaseEventRecordingProvider : IEventRecordingProvider
    {
        private static List<Type> _eventSaverTypes;
        private readonly IServiceProvider _serviceProvider;
        private List<EventSaver> _eventSavers;
        private readonly GameTilesRepo _gameTilesRepo;
        private readonly GameObjectsStepStateRepo _gameObjectsStepStateRepo;
        private List<EventSaver> EventSavers => _eventSavers ??= GetEventSavers();
        public static List<Type> EventSaverTypes => _eventSaverTypes ??= GetEventSaverTypes();
        public static Guid GameSessionId { get; set; }
        public static int StepId { get; set; }
        public DatabaseEventRecordingProvider(IServiceProvider serviceProvider, 
            GameTilesRepo gameTilesRepo, GameObjectsStepStateRepo gameObjectsStepStateRepo)
        {
            _serviceProvider = serviceProvider;
            _gameTilesRepo = gameTilesRepo;
            _gameObjectsStepStateRepo = gameObjectsStepStateRepo;
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
        private void FillGameTilesData(List<GameTile> tiles)
        {
            List<GameTiles> items = new List<GameTiles>();
            var stepId = StepId;
            foreach (var tile in tiles)
            {
                items.Add(new GameTiles
                {
                    StepId = stepId,
                    AreaTypeId = (int)tile.AreaType,
                    X = tile.Coordinates.X,
                    Y = tile.Coordinates.Y
                });
            }
            _gameTilesRepo.Create(items);
        }
        private void FillGameObjectsStepStateData(List<GameObject> gameObjects)
        {
            List<GameObjectsStepState> items = new List<GameObjectsStepState>();
            var stepId = StepId;
            foreach (var gameObject in gameObjects)
            {
                var objects = new List<GameObject> { gameObject };
                var dataHolder = new GameObjectsStepState
                {
                    GameObjectId = gameObject.Id,
                    StepId = stepId,
                    TypeName = gameObject.GetType().Name,
                    X = gameObject.Coordinates.X,
                    Y = gameObject.Coordinates.Y,
                    Hp = gameObject.Hp,
                    StatusId = (int)gameObject.Status,
                };
                if (objects.OfType<IGrowable>().Any())
                {
                    var growable = objects.OfType<IGrowable>().Single();
                    dataHolder.CurrentAge = growable.CurrentAge;
                }
                if (objects.OfType<IGender>().Any())
                {
                    var genderObj = objects.OfType<IGender>().Single();
                    dataHolder.GenderTypeId = (int)genderObj.GenderType;
                    dataHolder.CurrentPregnancyTime = genderObj.CurrentPregnancyTime;
                    dataHolder.IsPregnant = genderObj.IsPregnant;
                }
                items.Add(dataHolder);
            }
            _gameObjectsStepStateRepo.Create(items);
        }
    }
}
