using Life.DAL.DatabaseFirst.Models;

namespace Life.DAL.DatabaseFirst.Repositories
{
    public class EventsRepo : GenericRepository<Events>
    {
        public EventsRepo(LifeGameDBContext dbContext) : base(dbContext)
        {
        }
    }
}