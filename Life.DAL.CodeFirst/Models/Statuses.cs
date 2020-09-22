using System.Collections.Generic;

namespace Life.DAL.CodeFirst.Models
{
    public partial class Statuses
    {
        public Statuses()
        {
            GameObjectsStepState = new HashSet<GameObjectsStepState>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameObjectsStepState> GameObjectsStepState { get; set; }
    }
}
