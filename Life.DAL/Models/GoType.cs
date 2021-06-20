using System.Collections.Generic;

namespace Life.DAL.Models
{
    public partial class GoType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsFullyEatable { get; set; }
        public bool? IsEverGrowing { get; set; }

        public virtual ICollection<GoStepStartState> GameObjectsStepState { get; set; }
        public virtual ICollection<GoSessionTypes> GameObjectsSessionTypes { get; set; }
        public virtual ICollection<SessionPartiallyEatableTypes> SessionPartiallyEatableTypes { get; set; }
        public virtual ICollection<SessionTypesMoveTypes> SessionTypesMoveTypes { get; set; }
        public virtual ICollection<GameObject> GameObjects { get; set; }
    }
}