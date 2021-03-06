﻿using System.Collections.Generic;

namespace Life.DAL.CodeFirst.Models
{
    public class Steps
    {
        public Steps()
        {
            GameObjectsStepState = new HashSet<GameObjectsStepState>();
            GameTiles = new HashSet<GameTiles>();
        }

        public int Id { get; set; }
        public int SessionId { get; set; }
        public int Number { get; set; }

        public virtual Sessions Session { get; set; }
        public virtual ICollection<GameObjectsStepState> GameObjectsStepState { get; set; }
        public virtual ICollection<GameTiles> GameTiles { get; set; }
    }
}
