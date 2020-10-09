using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life.DAL.DatabaseFirst.Models
{
    [Table("GameObjectsTypes")]
    public partial class GameObjectsTypes
    {
        [Key]
        [MaxLength(50)]
        public string TypeName { get; set; }
        public bool? IsFullyEatable { get; set; }
        public bool? IsEverGrowing { get; set; }

        public virtual ICollection<GameObjectsStepState> GameObjectsStepState { get; set; }
        public virtual ICollection<GameObjectsSessionTypes> GameObjectsSessionTypes { get; set; }
    }
}
