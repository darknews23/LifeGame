using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class GameObjectsTypesRepo : GenericRepository<GoType>
    {
        public GameObjectsTypesRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}