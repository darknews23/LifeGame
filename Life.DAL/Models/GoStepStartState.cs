using System;

namespace Life.DAL.Models
{
    public partial class GoStepStartState
    {
        public Guid GameObjectId { get; set; }
        public Guid StepId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Hp { get; set; }
        public int Status { get; set; }
        public int? CurrentAge { get; set; }
        public int? GenderType { get; set; }
        public int? CurrentPregnancyTime { get; set; }

        public virtual Step Step { get; set; }
        public virtual GameObject GameObject { get; set; }
    }
}