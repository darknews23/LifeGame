using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life.DAL.DatabaseFirst.Models
{
    [Table("SessionPartiallyEatableTypes")]
    public partial class SessionPartiallyEatableTypes
    {
        [Key]
        [MaxLength(50)]
        public string TypeName { get; set; }
        [Key]
        public Guid SessionId { get; set; }
        [Required]
        public int BeingEatenDamage { get; set; }

        public virtual Sessions Session { get; set; }
    }
}
