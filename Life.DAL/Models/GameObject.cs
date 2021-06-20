using System;
using System.Collections.Generic;

namespace Life.DAL.Models
{
    public partial class GameObject
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public int TypeId { get; set; }
        public int Status { get; set; }
        public int? CurrentAge { get; set; }
        public int? GenderType { get; set; }

        public virtual GoType Type { get; set; }
        public virtual Session Session { get; set; }
        public virtual ICollection<Events> PerformedEvents { get; set; }
        public virtual ICollection<Events> AffectedByEvents { get; set; }
        public virtual ICollection<GoStepStartState> GoStepStartStates { get; set; }
    }
}