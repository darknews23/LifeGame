using System;
using System.Collections.Generic;

namespace Life.DAL.DatabaseFirst.Models
{
    public partial class GameObjectsTypes
    {
        public string TypeName { get; set; }
        public bool? IsFullyEatable { get; set; }
        public bool? IsEverGrowing { get; set; }

        public virtual ICollection<GameObjectsStepState> GameObjectsStepState { get; set; }
        public virtual ICollection<GameObjectsSessionTypes> GameObjectsSessionTypes { get; set; }
    }
}
