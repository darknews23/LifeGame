using System;
using System.Collections.Generic;

namespace Life.DAL.CodeFirst.Models
{
    public class Sessions
    {
        public Sessions()
        {
            GameObjectsSessionState = new HashSet<GameObjectsSessionState>();
            Steps = new HashSet<Steps>();
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<GameObjectsSessionState> GameObjectsSessionState { get; set; }
        public virtual ICollection<Steps> Steps { get; set; }
    }
}
