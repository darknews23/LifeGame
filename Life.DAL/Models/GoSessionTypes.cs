using System;

namespace Life.DAL.Models
{
    public partial class GoSessionTypes
    {
        public int GameObjectTypeId { get; set; }
        public Guid SessionId { get; set; }
        public int? InitialHp { get; set; }
        public int? MaxBirth { get; set; }
        public int? BirthTime { get; set; }
        public int? AdultAge { get; set; }

        public virtual GoType GoType { get; set; }
        public virtual Session Session { get; set; }
    }
}