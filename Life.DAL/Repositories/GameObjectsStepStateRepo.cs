using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class GameObjectsStepStateRepo : GenericRepository<GameObjectsStepState>
    {
        public GameObjectsStepStateRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}