using System.Collections.Generic;

namespace Life.DAL.CodeFirst.Models
{
    public class GenderTypes
    {
        public GenderTypes()
        {
            GameObjectsStepState = new HashSet<GameObjectsStepState>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameObjectsStepState> GameObjectsStepState { get; set; }
    }
}
