using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class GameObjectsSessionTypesRepo : GenericRepository<GameObjectsSessionTypes>
    {
        public GameObjectsSessionTypesRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}