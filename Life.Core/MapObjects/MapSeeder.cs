using System;
using System.Collections.Generic;
using System.Linq;
using Life.Core.Events;
using Life.Core.GameObjects;
using Life.Core.Interfaces;

namespace Life.Core.MapObjects
{
    public class MapSeeder : IGenerator
    {
        private readonly IMap _map;
        private static List<Type> _gameObjectTypes;

        public static List<Type> GameObjectTypes => _gameObjectTypes ??= GetGameObjectTypes();
        private static IServiceProvider _serviceProvider;
        private readonly GameObjectsCreationEvent _gameObjectsCreationEvent;
        private readonly IEventRecorder _eventRecorder;

        public MapSeeder(IMap map, IServiceProvider serviceProvider, GameObjectsCreationEvent gameObjectsCreationEvent, IEventRecorder eventRecorder)
        {
            _map = map;
            _serviceProvider = serviceProvider;
            _gameObjectsCreationEvent = gameObjectsCreationEvent;
            _eventRecorder = eventRecorder;
        }

        public void Generate()
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (var type in _gameObjectTypes)
                {
                    _map.GameObjects.Add(CreateObject(type));
                }
            }
            _gameObjectsCreationEvent.GameObjects = _map.GameObjects;
            _gameObjectsCreationEvent.StepNumber = GameSession.StepCount;

            _eventRecorder.Record(_gameObjectsCreationEvent);
        }
        public static BaseGameObject CreateObject(Type type, Coordinates coordinates)
        {
            if (!GameObjectTypes.Contains(type))
            {
                throw new ArgumentException("No such type found", nameof(type));
            }
            var gameObject = (BaseGameObject) _serviceProvider.GetService(type);
            gameObject.Coordinates = coordinates;
            return gameObject;
            
        }
        public static BaseGameObject CreateObject(Type type)
        {
            return GameObjectTypes.Contains(type)
                ? (BaseGameObject) _serviceProvider.GetService(type)
                : throw new ArgumentException("No such type found", nameof(type));
        }
        public static List<Type> GetGameObjectTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsSubclassOf(typeof(BaseGameObject)) && !x.IsAbstract)
                .ToList();
        }
    }
}
