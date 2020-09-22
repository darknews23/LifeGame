using Life.DAL.DatabaseFirst.Models;

namespace Life.DAL.DatabaseFirst.Repositories
{
    public class SessionsRepo : GenericRepository<Sessions>
    {
        public SessionsRepo(LifeGameDBContext dbContext) : base(dbContext)
        {
        }
    }
}