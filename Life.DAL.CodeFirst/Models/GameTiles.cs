namespace Life.DAL.CodeFirst.Models
{
    public class GameTiles
    {
        public int Id { get; set; }
        public int StepId { get; set; }
        public int AreaTypeId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public virtual AreaTypes AreaType { get; set; }
        public virtual Steps Step { get; set; }
    }
}
