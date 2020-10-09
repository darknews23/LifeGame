using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life.DAL.DatabaseFirst.Models
{
    [Table("Events")]
    public partial class Events
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StepId { get; set; }
        [Required]
        public int ActionId { get; set; }
        [Required]
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
