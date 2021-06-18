using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class SessionsRepo : GenericRepository<Sessions>
    {
        public SessionsRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}