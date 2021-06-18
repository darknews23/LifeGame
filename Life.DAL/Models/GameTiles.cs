using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Life.DAL.Models
{
    [Table("GameTiles")]
    public partial class GameTiles
    {
        [Key]
        public int StepId { get; set; }
        [Key]
        public int X { get; set; }
        [Key]
        public int Y { get; set; }
        [Required]
        public int AreaTypeId { get; set; }

        public virtual Steps Step { get; set; }
    }
}
