using System;

namespace Life.DAL.Models
{
    
    public partial class Events
    {
        public Guid Id { get; set; }
        public int StepId { get; set; }
        public int ActionType { get; set; }
        public int ActorObjectId { get; set; }
        public int? AffectedObjectId { get; set; }
        public bool? BecameAdult { get; set; }
        public int? HpChange { get; set; }
        public int? Direction { get; set; }
        public int? Distance { get; set; }
        public int? MoveType { get; set; }

        public virtual Step Step { get; set; }
        public virtual GameObject ActorObject { get; set; }
        public virtual GameObject AffectedObject { get; set; }
    }
}
