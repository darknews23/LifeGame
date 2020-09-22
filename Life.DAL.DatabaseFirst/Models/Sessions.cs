using System;
using System.Collections.Generic;

namespace Life.DAL.DatabaseFirst.Models
{
    public partial class Sessions
    {
        public Sessions()
        {
            SessionPartiallyEatableTypes = new HashSet<SessionPartiallyEatableTypes>();
            SessionTypesMoveTypes = new HashSet<SessionTypesMoveTypes>();
            Steps = new HashSet<Steps>();
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<SessionPartiallyEatableTypes> SessionPartiallyEatableTypes { get; set; }
        public virtual ICollection<SessionTypesMoveTypes> SessionTypesMoveTypes { get; set; }
        public virtual ICollection<Steps> Steps { get; set; }
    }
}
