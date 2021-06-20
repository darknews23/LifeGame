using System;
using System.IO;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    class DeathSaver : ActionEventSaver
    {
        public override Type SaveableEventType => typeof(DeathEvent);

        public DeathSaver(LifeGameDbContext context, StepsRepo stepsRepo, EventsRepo eventsRepo,
            GOStepStartStateRepo goStepStartStateRepo) : base(context, stepsRepo, eventsRepo, goStepStartStateRepo)
        {

        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is DeathEvent ev)
            {
               EventsRepo.Create(new Events()
                {
                    ActionType = (int)ev.ActionType,
                    StepId = DatabaseEventRecordingProvider.StepId, 
                    ActorObjectId = ev.ActorId,
                });
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
        }
    }
}