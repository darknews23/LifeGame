using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class GameObjectsTypesRepo : GenericRepository<GameObjectsTypes>
    {
        public GameObjectsTypesRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}