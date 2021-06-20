using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class GameTilesRepo : GenericRepository<GameTile>
    {
        public GameTilesRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}