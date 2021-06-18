using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    public abstract class ActionEventSaver : StepEventSaver
    {
        protected EventsRepo EventsRepo { get; }
        protected GameObjectsStepStateRepo GameObjectsStepStateRepo { get; }

        protected ActionEventSaver(LifeGameDbContext context, StepsRepo stepsRepo, EventsRepo eventsRepo,
            GameObjectsStepStateRepo gameObjectsStepStateRepo) : base(context, stepsRepo)
        {
            EventsRepo = eventsRepo;
            GameObjectsStepStateRepo = gameObjectsStepStateRepo;
        }
    }
}
