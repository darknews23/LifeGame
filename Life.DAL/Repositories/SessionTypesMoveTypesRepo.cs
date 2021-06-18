using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class SessionTypesMoveTypesRepo : GenericRepository<SessionTypesMoveTypes>
    {
        public SessionTypesMoveTypesRepo(LifeGameDbContext dbContext) : base(dbContext)
        {

        }
    }
}