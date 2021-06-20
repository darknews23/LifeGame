using System;

namespace Life.DAL.Models
{
    public partial class GameTile
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int AreaType { get; set; }

        public virtual Session Session { get; set; }
    }
}