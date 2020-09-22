using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Life.Core.Events;
using Life.Core.GameObjects;
using Life.Core.Interfaces;
using Life.DAL.DatabaseFirst.Models;
using Life.DAL.DatabaseFirst.Repositories;

namespace Life.DAL.DatabaseFirst.EventSavers
{
    class GameObjectsCreationSaver : ActionEventSaver
    {
        public override Type SaveableEventType => typeof(GameObjectsCreationEvent);

        public GameObjectsCreationSaver(LifeGameDBContext context, StepsRepo stepsRepo, EventsRepo eventsRepo, 
            GameObjectsStepStateRepo gameObjectsStepStateRepo) : base(context, stepsRepo, eventsRepo, gameObjectsStepStateRepo)
        {

        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is GameObjectsCreationEvent ev)
            {
                var stepId = DatabaseEventRecordingProvider.StepId;
                var items = new List<GameObjectsStepState>();
                foreach (var gameObject in ev.GameObjects)
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
                GameObjectsStepStateRepo.Create(items);
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
            
        }
    }
}