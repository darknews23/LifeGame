using Life.DAL.DatabaseFirst.Models;
using Life.DAL.DatabaseFirst.Repositories;

namespace Life.DAL.DatabaseFirst.EventSavers
{
    public abstract class ActionEventSaver : StepEventSaver
    {
        protected EventsRepo EventsRepo { get; }
        protected GameObjectsStepStateRepo GameObjectsStepStateRepo { get; }

        protected ActionEventSaver(LifeGameDBContext context, StepsRepo stepsRepo, EventsRepo eventsRepo,
            GameObjectsStepStateRepo gameObjectsStepStateRepo) : base(context, stepsRepo)
        {
            EventsRepo = eventsRepo;
            GameObjectsStepStateRepo = gameObjectsStepStateRepo;
        }
    }
}
