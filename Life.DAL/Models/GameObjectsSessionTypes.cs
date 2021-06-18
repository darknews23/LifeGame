using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life.DAL.Models
{
    [Table("GameObjectsSessionTypes")]
    public partial class GameObjectsSessionTypes
    {
        [Key]
        [MaxLength(50)]
        public string TypeName { get; set; }
        [Key]
        public Guid SessionId { get; set; }
        public int? InitialHp { get; set; }
        public int? MaxBirth { get; set; }
        public int? BirthTime { get; set; }
        public int? AdultAge { get; set; }

        public virtual GameObjectsTypes Type { get; set; }
    }
}
