using System;
using System.IO;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    class PregnancyProgressionSaver : ActionEventSaver
    {
        public override Type SaveableEventType => typeof(PregnancyProgressionEvent);

        public PregnancyProgressionSaver(LifeGameDbContext context, StepsRepo stepsRepo, EventsRepo eventsRepo,
            GOStepStartStateRepo goStepStartStateRepo) : base(context, stepsRepo, eventsRepo, goStepStartStateRepo)
        {

        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is PregnancyProgressionEvent ev)
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