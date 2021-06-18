using System;
using System.IO;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    class StepSaver : StepEventSaver
    {
        public override Type SaveableEventType => typeof(NewStepEvent);

        public StepSaver(LifeGameDbContext context, StepsRepo stepsRepo) : base(context, stepsRepo)
        {

        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is NewStepEvent ev)
            {
                StepsRepo.Create(new Steps
                {
                    SessionId = DatabaseEventRecordingProvider.GameSessionId,
                    Number = ev.StepNumber
                });
                DatabaseEventRecordingProvider.StepId = StepsRepo.GetStepId(ev.StepNumber);
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
        }
    }
}