using System;
using System.Collections.Generic;

namespace Life.DAL.Models
{
    public partial class Step
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public int Number { get; set; }

        public virtual Session Session { get; set; }
        public virtual ICollection<Events> Events { get; set; }
        public virtual ICollection<GoStepStartState> GOStepStartStates { get; set; }
    }
}
