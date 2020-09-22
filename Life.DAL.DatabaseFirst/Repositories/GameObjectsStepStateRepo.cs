using Life.DAL.DatabaseFirst.Models;

namespace Life.DAL.DatabaseFirst.Repositories
{
    public class GameObjectsStepStateRepo : GenericRepository<GameObjectsStepState>
    {
        public GameObjectsStepStateRepo(LifeGameDBContext dbContext) : base(dbContext)
        {
        }
    }
}