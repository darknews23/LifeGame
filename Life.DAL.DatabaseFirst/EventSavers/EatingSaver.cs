using System;
using System.IO;
using System.Linq;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.DAL.DatabaseFirst.Models;
using Life.DAL.DatabaseFirst.Repositories;

namespace Life.DAL.DatabaseFirst.EventSavers
{
    class EatingSaver : ActionEventSaver
    {
        public override Type SaveableEventType => typeof(EatingEvent);

        public EatingSaver(LifeGameDBContext context, StepsRepo stepsRepo, EventsRepo eventsRepo,
            GameObjectsStepStateRepo gameObjectsStepStateRepo)
            : base(context, stepsRepo, eventsRepo, gameObjectsStepStateRepo)
        {

        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is EatingEvent ev)
            {
                EventsRepo.Create(new Events()
                {
                    ActionId = (int)ev.ActionType,
                    StepId = DatabaseEventRecordingProvider.StepId,
                    GameObjectId1 = ev.ActorId,
                    HpChange = ev.HpChange,
                    GameObjectId2 = ev.VictimId
                });
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
        }
    }
}