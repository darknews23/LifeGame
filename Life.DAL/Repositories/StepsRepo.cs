using System.Linq;
using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class StepsRepo : GenericRepository<Steps>
    {
        public StepsRepo(LifeGameDbContext dbContext) : base(dbContext)
        {

        }
        public int GetStepId(int stepNumber)
        {
            return Get(x =>
                    x.SessionId == DatabaseEventRecordingProvider.GameSessionId &&
                    x.Number == stepNumber)
                .Single()
                .Id;
        }
    }
}
