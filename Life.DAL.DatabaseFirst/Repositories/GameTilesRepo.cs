using Life.DAL.DatabaseFirst.Models;

namespace Life.DAL.DatabaseFirst.Repositories
{
    public class GameTilesRepo : GenericRepository<GameTiles>
    {
        public GameTilesRepo(LifeGameDBContext dbContext) : base(dbContext)
        {
        }
    }
}