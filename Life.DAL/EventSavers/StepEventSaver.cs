using Life.DAL.Models;
using Life.DAL.Repositories;

namespace Life.DAL.EventSavers
{
    public abstract class StepEventSaver : EventSaver
    {
        protected StepsRepo StepsRepo { get; }
        protected StepEventSaver(LifeGameDbContext context, StepsRepo stepsRepo) : base(context)
        {
            StepsRepo = stepsRepo;
        }
    }
}
