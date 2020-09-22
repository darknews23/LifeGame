using Life.DAL.DatabaseFirst.Models;

namespace Life.DAL.DatabaseFirst.Repositories
{
    public class SessionTypesMoveTypesRepo : GenericRepository<SessionTypesMoveTypes>
    {
        public SessionTypesMoveTypesRepo(LifeGameDBContext dbContext) : base(dbContext)
        {

        }
    }
}