using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life.DAL.DatabaseFirst.Models
{
    [Table("GameObjectsStepState")]
    public partial class GameObjectsStepState
    {
        [Key]
        public int GameObjectId { get; set; }
        [Key]
        [MaxLength(50)]
        public string TypeName { get; set; }
        [Key]
        public int StepId { get; set; }
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
        [Required]
        public int Hp { get; set; }
        [Required]
        public int StatusId { get; set; }
        public int? CurrentAge { get; set; }
        public int? GenderTypeId { get; set; }
        public int? CurrentPregnancyTime { get; set; }
        public bool? IsPregnant { get; set; }

        public virtual Steps Step { get; set; }
        public virtual GameObjectsTypes Type { get; set; }
    }
}
