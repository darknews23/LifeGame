using System.Linq;
using Life.DAL.DatabaseFirst.Models;

namespace Life.DAL.DatabaseFirst.Repositories
{
    public class StepsRepo : GenericRepository<Steps>
    {
        public StepsRepo(LifeGameDBContext dbContext) : base(dbContext)
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
