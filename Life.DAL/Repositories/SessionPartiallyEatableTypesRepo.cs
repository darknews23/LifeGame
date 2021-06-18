using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class SessionPartiallyEatableTypesRepo : GenericRepository<SessionPartiallyEatableTypes>
    {
        public SessionPartiallyEatableTypesRepo(LifeGameDbContext dbContext) : base(dbContext)
        {
        }
    }
}