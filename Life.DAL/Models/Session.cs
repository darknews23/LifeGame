using System;
using System.Collections.Generic;

namespace Life.DAL.Models
{
    public partial class Session
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<SessionPartiallyEatableTypes> SessionPartiallyEatableTypes { get; set; }
        public virtual ICollection<SessionTypesMoveTypes> SessionTypesMoveTypes { get; set; }
        public virtual ICollection<GoSessionTypes> GameObjectsSessionTypes { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
        public virtual ICollection<GameTile> GameTiles { get; set; }
        public virtual ICollection<GameObject> GameObjects { get; set; }
    }
}
