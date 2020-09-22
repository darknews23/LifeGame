using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Life.Core.Events;
using Life.Core.GameObjects;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Life.DAL.DatabaseFirst.Models;
using Life.DAL.DatabaseFirst.Repositories;

namespace Life.DAL.DatabaseFirst.EventSavers
{
    class GameSessionSaver : EventSaver
    {
        public override Type SaveableEventType => typeof(NewGameSessionEvent);
        private readonly IServiceProvider _serviceProvider;
        private readonly SessionsRepo _sessionsRepo;
        private readonly GameObjectsSessionTypesRepo _gameObjectsSessionTypesRepo;
        private readonly SessionTypesMoveTypesRepo _sessionTypesMoveTypesRepo;
        private readonly SessionPartiallyEatableTypesRepo _sessionPartiallyEatableTypesRepo;
        public override void Save(IEvent eventObj)
        {
            if (eventObj is NewGameSessionEvent ev)
            {
                _sessionsRepo.Create(new Sessions() {Created = ev.Created});
                DatabaseEventRecordingProvider.GameSessionId = _sessionsRepo.Get().Last().Id;
                FillSessionData();
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
        }

        public GameSessionSaver(LifeGameDBContext context, IServiceProvider serviceProvider, SessionsRepo sessionsRepo,
            GameObjectsSessionTypesRepo gameObjectsSessionTypesRepo, 
            SessionTypesMoveTypesRepo sessionTypesMoveTypesRepo, SessionPartiallyEatableTypesRepo sessionPartiallyEatableTypesRepo) : base(context)
        {
            _serviceProvider = serviceProvider;
            _sessionsRepo = sessionsRepo;
            _gameObjectsSessionTypesRepo = gameObjectsSessionTypesRepo;
            _sessionTypesMoveTypesRepo = sessionTypesMoveTypesRepo;
            _sessionPartiallyEatableTypesRepo = sessionPartiallyEatableTypesRepo;
        }

        private void FillSessionData()
        {
            var gameObjects = new List<GameObject>();
            foreach (var type in MapSeeder.GameObjectTypes)
            {
                var gameObject = (GameObject)_serviceProvider.GetService(type);
                gameObjects.Add(gameObject);
            }
            FillSessionTypesData(gameObjects);
            FillSessionTypesMoveTypes(gameObjects);
            FillSessionPartiallyEatableTypes(gameObjects);
        }

        private void FillSessionTypesMoveTypes(List<GameObject> gameObjects)
        {
            var items = new List<SessionTypesMoveTypes>();
            var movables = gameObjects.OfType<IMovable>().ToList();
            foreach (var movable in movables)
            {
                foreach (var (moveType, speed) in movable.AllowedMoveTypes)
                {
                    items.Add(new SessionTypesMoveTypes()
                    {
                        TypeName = movable.GetType().Name,
                        MoveTypeId = (int) moveType,
                        SessionId = DatabaseEventRecordingProvider.GameSessionId,
                        Speed = speed
                    });
                }
            }

            _sessionTypesMoveTypesRepo.Create(items);
        }
        private void FillSessionTypesData(List<GameObject> gameObjects)
        {
            var items = new List<GameObjectsSessionTypes>();
            foreach (var gameObject in gameObjects)
            {
                var item = new GameObjectsSessionTypes
                {
                    SessionId = DatabaseEventRecordingProvider.GameSessionId,
                    TypeName = gameObject.GetType().Name,
                    InitialHp = gameObject.Hp
                };
                
                if (gameObject is IGrowable growable)
                {
                    item.AdultAge = growable.AdultAge;
                }

                if (gameObject is IGender genderObject)
                {
                    item.MaxBirth = genderObject.MaxBirth;
                    item.BirthTime = genderObject.BirthTime;
                }

                items.Add(item);
            }
            _gameObjectsSessionTypesRepo.Create(items);
        }
        private void FillSessionPartiallyEatableTypes(List<GameObject> gameObjects)
        {
            var items = new List<SessionPartiallyEatableTypes>();
            var eatables = gameObjects.OfType<IEatable>().Where(x => x.IsFullyEatable == false).ToList();
            foreach (var eatable in eatables)
            {
                items.Add(new SessionPartiallyEatableTypes
                {
                    SessionId = DatabaseEventRecordingProvider.GameSessionId,
                    TypeName = eatable.GetType().Name,
                    BeingEatenDamage = eatable.BeingEatenDamage
                });
            }
            _sessionPartiallyEatableTypesRepo.Create(items);
        }
    }
}
