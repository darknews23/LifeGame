using System.Collections.Generic;

namespace Life.DAL.CodeFirst.Models
{
    public class GameObjectsTypes
    {
        public GameObjectsTypes()
        {
            GameObjects = new HashSet<GameObjects>();
            GameObjectsSessionState = new HashSet<GameObjectsSessionState>();
            GameObjectsStepState = new HashSet<GameObjectsStepState>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameObjects> GameObjects { get; set; }
        public virtual ICollection<GameObjectsSessionState> GameObjectsSessionState { get; set; }
        public virtual ICollection<GameObjectsStepState> GameObjectsStepState { get; set; }
    }
}
