using System;
using System.Collections.Generic;

namespace Life.DAL.DatabaseFirst.Models
{
    public partial class GameTiles
    {
        public int StepId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int AreaTypeId { get; set; }

        public virtual Steps Step { get; set; }
    }
}
