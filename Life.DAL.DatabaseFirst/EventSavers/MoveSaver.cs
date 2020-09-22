using System;
using System.IO;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.DAL.DatabaseFirst.Models;
using Life.DAL.DatabaseFirst.Repositories;

namespace Life.DAL.DatabaseFirst.EventSavers
{
    class MoveSaver : ActionEventSaver
    {
        public override Type SaveableEventType => typeof(MovementEvent);

        public MoveSaver(LifeGameDBContext context, StepsRepo stepsRepo, EventsRepo eventsRepo,
            GameObjectsStepStateRepo gameObjectsStepStateRepo) : base(context, stepsRepo, eventsRepo, gameObjectsStepStateRepo)
        {

        }

        public override void Save(IEvent eventObj)
        {
            if (eventObj is MovementEvent ev)
            {
                EventsRepo.Create(new Events
                {
                    ActionId = (int)ev.ActionType,
                    StepId = DatabaseEventRecordingProvider.StepId,
                    GameObjectId1 = ev.ActorId,
                    DirectionId = (int)ev.Direction,
                    Distance = ev.Distance,
                    MoveTypeId = (int)ev.MoveType
                });
            }
            else
            {
                throw new InvalidDataException($"{eventObj} is invalid event");
            }
        }
    }
}