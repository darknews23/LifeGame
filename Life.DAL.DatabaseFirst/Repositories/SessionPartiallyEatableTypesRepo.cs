using Life.DAL.DatabaseFirst.Models;

namespace Life.DAL.DatabaseFirst.Repositories
{
    public class SessionPartiallyEatableTypesRepo : GenericRepository<SessionPartiallyEatableTypes>
    {
        public SessionPartiallyEatableTypesRepo(LifeGameDBContext dbContext) : base(dbContext)
        {
        }
    }
}