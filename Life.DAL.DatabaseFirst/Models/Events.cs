using System;
using System.Collections.Generic;

namespace Life.DAL.DatabaseFirst.Models
{
    public partial class Events
    {
        public int Id { get; set; }
        public int StepId { get; set; }
        public int ActionId { get; set; }
        public int GameObjectId1 { get; set; }
        public int? GameObjectId2 { get; set; }
        public bool? BecameAdult { get; set; }
        public int? HpChange { get; set; }
        public int? DirectionId { get; set; }
        public int? Distance { get; set; }
        public int? MoveTypeId { get; set; }

        public virtual Steps Step { get; set; }
    }
}
