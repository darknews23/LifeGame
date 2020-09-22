using Life.DAL.DatabaseFirst.Models;
using Life.DAL.DatabaseFirst.Repositories;

namespace Life.DAL.DatabaseFirst.EventSavers
{
    public abstract class StepEventSaver : EventSaver
    {
        protected StepsRepo StepsRepo { get; }
        protected StepEventSaver(LifeGameDBContext context, StepsRepo stepsRepo) : base(context)
        {
            StepsRepo = stepsRepo;
        }
    }
}
