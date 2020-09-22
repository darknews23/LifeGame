using System;
using System.Collections.Generic;

namespace Life.DAL.DatabaseFirst.Models
{
    public partial class GameObjectsStepState
    {
        public int GameObjectId { get; set; }
        public string TypeName { get; set; }
        public int StepId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Hp { get; set; }
        public int StatusId { get; set; }
        public int? CurrentAge { get; set; }
        public int? GenderTypeId { get; set; }
        public int? CurrentPregnancyTime { get; set; }
        public bool? IsPregnant { get; set; }

        public virtual Steps Step { get; set; }
        public virtual GameObjectsTypes Type { get; set; }
    }
}
