using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class SessionsRepo : GenericRepository<Session>
    {
        public SessionsRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}