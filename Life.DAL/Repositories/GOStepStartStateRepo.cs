using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class GOStepStartStateRepo : GenericRepository<GoStepStartState>
    {
        public GOStepStartStateRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}