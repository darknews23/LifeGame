using System.Collections.Generic;

namespace Life.DAL.CodeFirst.Models
{
    public class MoveTypes
    {
        public MoveTypes()
        {
            GameObjectsMoveTypes = new HashSet<GameObjectsMoveTypes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Events Events { get; set; }
        public virtual ICollection<GameObjectsMoveTypes> GameObjectsMoveTypes { get; set; }
    }
}
