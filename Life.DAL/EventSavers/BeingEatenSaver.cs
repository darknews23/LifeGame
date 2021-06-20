using System;
using System.IO;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    class BeingEatenSaver : ActionEventSaver
    {
        public override Type SaveableEventType => typeof(BeingEatenEvent);

        public BeingEatenSaver(LifeGameDbContext context, StepsRepo stepsRepo, EventsRepo eventsRepo, 
            GOStepStartStateRepo goStepStartStateRepo) : base(context, stepsRepo, eventsRepo, goStepStartStateRepo)
        {

        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is BeingEatenEvent ev)
            {
                EventsRepo.Create(new Events()
                {
                    ActionType = (int)ev.ActionType,
                    StepId = DatabaseEventRecordingProvider.StepId,
                    ActorObjectId = ev.ActorId,
                    HpChange = ev.HpChange
                });
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
        }
    }
}