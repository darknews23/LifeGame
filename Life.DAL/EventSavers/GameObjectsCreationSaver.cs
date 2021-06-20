using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Life.Core.Events;
using Life.Core.GameObjects;
using Life.Core.Interfaces;
using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    class GameObjectsCreationSaver : ActionEventSaver
    {
        public override Type SaveableEventType => typeof(GameObjectsCreationEvent);

        public GameObjectsCreationSaver(LifeGameDbContext context, StepsRepo stepsRepo, EventsRepo eventsRepo, 
            GOStepStartStateRepo goStepStartStateRepo) : base(context, stepsRepo, eventsRepo, goStepStartStateRepo)
        {

        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is GameObjectsCreationEvent ev)
            {
                var stepId = DatabaseEventRecordingProvider.StepId;
                var items = new List<GoStepStartState>();
                foreach (var gameObject in ev.GameObjects)
                {
                    var objects = new List<GameObject> { gameObject };
                    var dataHolder = new GoStepStartState
                    {
                        GameObjectId = gameObject.Id,
                        StepId = stepId,
                        TypeName = gameObject.GetType().Name,
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
                        dataHolder.IsPregnant = genderObj.IsPregnant;
                    }
                    items.Add(dataHolder);
                }
                GoStepStartStateRepo.Create(items);
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
            
        }
    }
}