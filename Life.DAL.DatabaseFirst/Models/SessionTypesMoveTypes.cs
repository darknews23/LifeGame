using System;
using System.Collections.Generic;

namespace Life.DAL.DatabaseFirst.Models
{
    public partial class SessionTypesMoveTypes
    {
        public string TypeName { get; set; }
        public int MoveTypeId { get; set; }
        public int SessionId { get; set; }
        public int Speed { get; set; }

        public virtual Sessions Session { get; set; }
    }
}
