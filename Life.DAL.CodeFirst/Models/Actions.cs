using System.Collections.Generic;

namespace Life.DAL.CodeFirst.Models
{
    public class Actions
    {
        public Actions()
        {
            Events = new HashSet<Events>();
            GameObjects = new HashSet<GameObjects>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Events> Events { get; set; }
        public virtual ICollection<GameObjects> GameObjects { get; set; }
    }
}
