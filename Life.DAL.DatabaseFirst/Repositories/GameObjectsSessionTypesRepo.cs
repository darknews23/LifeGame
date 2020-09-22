using Life.DAL.DatabaseFirst.Models;

namespace Life.DAL.DatabaseFirst.Repositories
{
    public class GameObjectsSessionTypesRepo : GenericRepository<GameObjectsSessionTypes>
    {
        public GameObjectsSessionTypesRepo(LifeGameDBContext dbContext) : base(dbContext)
        {
        }
    }
}