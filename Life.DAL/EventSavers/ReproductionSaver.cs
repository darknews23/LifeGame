using System;
using System.IO;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    class ReproductionSaver : ActionEventSaver
    {
        public override Type SaveableEventType => typeof(ReproductionEvent);

        public ReproductionSaver(LifeGameDbContext context, StepsRepo stepsRepo, EventsRepo eventsRepo,
            GOStepStartStateRepo goStepStartStateRepo) : base(context, stepsRepo, eventsRepo, goStepStartStateRepo)
        {

        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is ReproductionEvent ev)
            {
                EventsRepo.Create(new Events
                {
                    ActionType = (int)ev.ActionType,
                    StepId = DatabaseEventRecordingProvider.StepId,
                    ActorObjectId = ev.ActorId,
                    AffectedObjectId = ev.FemaleId
                });
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
        }
    }
}