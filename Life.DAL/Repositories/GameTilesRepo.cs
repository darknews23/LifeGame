using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class GameTilesRepo : GenericRepository<GameTiles>
    {
        public GameTilesRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}