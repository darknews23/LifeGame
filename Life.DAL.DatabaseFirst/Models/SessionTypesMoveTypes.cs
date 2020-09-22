using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life.DAL.DatabaseFirst.Models
{
    [Table("SessionTypesMoveTypes")]
    public partial class SessionTypesMoveTypes
    {
        [Key]
        [MaxLength(50)]
        public string TypeName { get; set; }
        [Key]
        public int MoveTypeId { get; set; }
        [Key]
        public Guid SessionId { get; set; }
        [Required]
        public int Speed { get; set; }

        public virtual Sessions Session { get; set; }
    }
}
