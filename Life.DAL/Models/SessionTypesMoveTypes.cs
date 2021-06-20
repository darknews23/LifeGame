using System;

namespace Life.DAL.Models
{
    public partial class SessionTypesMoveTypes
    {
        public int GameObjectTypeId { get; set; }
        public Guid SessionId { get; set; }
        public int MoveType { get; set; }
        public int Speed { get; set; }

        public virtual Session Session { get; set; }
        public virtual GoType GoType { get; set; }
    }
}