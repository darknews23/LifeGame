using System.Collections.Generic;

namespace Life.DAL.CodeFirst.Models
{
    public class GameObjectsStepState
    {
        public GameObjectsStepState()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public int StepId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Hp { get; set; }
        public int StatusId { get; set; }
        public int? CurrentAge { get; set; }
        public int? GenderTypeId { get; set; }
        public int? CurrentPregnancyTime { get; set; }
        public bool? IsPregnant { get; set; }

        public virtual GenderTypes GenderType { get; set; }
        public virtual Statuses Status { get; set; }
        public virtual Steps Step { get; set; }
        public virtual GameObjectsTypes Type { get; set; }
        public virtual ICollection<Events> Events { get; set; }
    }
}
