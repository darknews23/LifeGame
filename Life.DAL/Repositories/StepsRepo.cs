using System;
using System.Linq;
using Life.DAL.Models;

namespace Life.DAL.Repositories
{
    public class StepsRepo : GenericRepository<Step>
    {
        public StepsRepo(LifeGameDbContext dbContext) : base(dbContext)
        {

        }
        public Guid GetStepId(int stepNumber)
        {
            return Get(x =>
                    x.SessionId == DatabaseEventRecordingProvider.GameSessionId &&
                    x.Number == stepNumber)
                .Single()
                .Id;
        }
    }
}
