using System.Collections.Generic;

namespace Life.DAL.CodeFirst.Models
{
    public class GameObjects
    {
        public GameObjects()
        {
            GameObjectsMoveTypes = new HashSet<GameObjectsMoveTypes>();
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public int Habitat { get; set; }
        public bool? IsEverGrowing { get; set; }
        public int? ActionId { get; set; }

        public virtual Actions Action { get; set; }
        public virtual AreaTypes HabitatNavigation { get; set; }
        public virtual GameObjectsTypes Type { get; set; }
        public virtual ICollection<GameObjectsMoveTypes> GameObjectsMoveTypes { get; set; }
    }
}
