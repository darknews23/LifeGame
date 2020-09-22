using System;
using System.Collections.Generic;

namespace Life.DAL.DatabaseFirst.Models
{
    public partial class SessionPartiallyEatableTypes
    {
        public string TypeName { get; set; }
        public int SessionId { get; set; }
        public int BeingEatenDamage { get; set; }

        public virtual Sessions Session { get; set; }
    }
}
