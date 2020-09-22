using Life.DAL.DatabaseFirst.Models;

namespace Life.DAL.DatabaseFirst.Repositories
{
    public class GameObjectsTypesRepo : GenericRepository<GameObjectsTypes>
    {
        public GameObjectsTypesRepo(LifeGameDBContext dbContext) : base(dbContext)
        {
        }
    }
}