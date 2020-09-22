using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life.DAL.DatabaseFirst.Models
{
    [Table("Steps")]
    public partial class Steps
    {
        public Steps()
        {
            Events = new HashSet<Events>();
            GameObjectsStepState = new HashSet<GameObjectsStepState>();
            GameTiles = new HashSet<GameTiles>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid SessionId { get; set; }
        [Required]
        public int Number { get; set; }

        public virtual Sessions Session { get; set; }
        public virtual ICollection<Events> Events { get; set; }
        public virtual ICollection<GameObjectsStepState> GameObjectsStepState { get; set; }
        public virtual ICollection<GameTiles> GameTiles { get; set; }
    }
}
