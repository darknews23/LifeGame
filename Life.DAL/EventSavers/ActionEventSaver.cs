using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    public abstract class ActionEventSaver : StepEventSaver
    {
        protected EventsRepo EventsRepo { get; }
        protected GOStepStartStateRepo GoStepStartStateRepo { get; }

        protected ActionEventSaver(LifeGameDbContext context, StepsRepo stepsRepo, EventsRepo eventsRepo,
            GOStepStartStateRepo goStepStartStateRepo) : base(context, stepsRepo)
        {
            EventsRepo = eventsRepo;
            GoStepStartStateRepo = goStepStartStateRepo;
        }
    }
}
