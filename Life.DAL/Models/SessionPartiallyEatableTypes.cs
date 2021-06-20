using System;

namespace Life.DAL.Models
{
    public partial class SessionPartiallyEatableTypes
    {
        public int GameObjectTypeId { get; set; }
        public Guid SessionId { get; set; }
        public int BeingEatenDamage { get; set; }

        public virtual Session Session { get; set; }
        public virtual GoType GoType { get; set; }
    }
}