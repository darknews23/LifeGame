using System;
using System.Collections.Generic;

namespace Life.DAL.DatabaseFirst.Models
{
    public partial class GameObjectsSessionTypes
    {
        public string TypeName { get; set; }
        public int SessionId { get; set; }
        public int? InitialHp { get; set; }
        public int? MaxBirth { get; set; }
        public int? BirthTime { get; set; }
        public int? AdultAge { get; set; }

        public virtual GameObjectsTypes Type { get; set; }
    }
}
