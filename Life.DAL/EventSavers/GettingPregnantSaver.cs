using System;
using System.IO;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    class GettingPregnantSaver : ActionEventSaver
    {
        public override Type SaveableEventType => typeof(GettingPregnantEvent);

        public GettingPregnantSaver(LifeGameDbContext context, StepsRepo stepsRepo, EventsRepo eventsRepo,
            GameObjectsStepStateRepo gameObjectsStepStateRepo) : base(context, stepsRepo, eventsRepo, gameObjectsStepStateRepo)
        {

        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is GettingPregnantEvent ev)
            {
                EventsRepo.Create(new Events()
                {
                    ActionId = (int)ev.ActionType,
                    StepId = DatabaseEventRecordingProvider.StepId,
                    GameObjectId1 = ev.ActorId,
                });
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
        }
    }
}