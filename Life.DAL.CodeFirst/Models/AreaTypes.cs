using System.Collections.Generic;

namespace Life.DAL.CodeFirst.Models
{
    public class AreaTypes
    {
        public AreaTypes()
        {
            GameObjects = new HashSet<GameObjects>();
            GameTiles = new HashSet<GameTiles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameObjects> GameObjects { get; set; }
        public virtual ICollection<GameTiles> GameTiles { get; set; }
    }
}
