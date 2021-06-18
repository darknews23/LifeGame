using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life.DAL.Models
{
    [Table("Sessions")]
    public partial class Sessions
    {
        public Sessions()
        {
            SessionPartiallyEatableTypes = new HashSet<SessionPartiallyEatableTypes>();
            SessionTypesMoveTypes = new HashSet<SessionTypesMoveTypes>();
            Steps = new HashSet<Steps>();
        }
        [Key]
        public Guid SessionId { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int GameStatusId { get; set; }

        public virtual ICollection<SessionPartiallyEatableTypes> SessionPartiallyEatableTypes { get; set; }
        public virtual ICollection<SessionTypesMoveTypes> SessionTypesMoveTypes { get; set; }
        public virtual ICollection<Steps> Steps { get; set; }
    }
}
