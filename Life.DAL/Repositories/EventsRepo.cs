using Life.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Life.DAL.Repositories
{
    public class EventsRepo : GenericRepository<Events>
    {
        public EventsRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}