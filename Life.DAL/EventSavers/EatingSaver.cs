using System;
using System.IO;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    class EatingSaver : ActionEventSaver
    {
        public override Type SaveableEventType => typeof(EatingEvent);

        public EatingSaver(LifeGameDbContext context, StepsRepo stepsRepo, EventsRepo eventsRepo,
            GOStepStartStateRepo goStepStartStateRepo)
            : base(context, stepsRepo, eventsRepo, goStepStartStateRepo)
        {

        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is EatingEvent ev)
            {
                EventsRepo.Create(new Events()
                {
                    ActionType = (int)ev.ActionType,
                    StepId = DatabaseEventRecordingProvider.StepId,
                    ActorObjectId = ev.ActorId,
                    HpChange = ev.HpChange,
                    AffectedObjectId = ev.VictimId
                });
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
        }
    }
}