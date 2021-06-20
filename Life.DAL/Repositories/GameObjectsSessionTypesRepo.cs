using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class GameObjectsSessionTypesRepo : GenericRepository<GoSessionTypes>
    {
        public GameObjectsSessionTypesRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}