namespace Life.DAL.CodeFirst.Models
{
    public class GameObjectsMoveTypes
    {
        public int GameObjectId { get; set; }
        public int MoveTypeId { get; set; }
        public int Speed { get; set; }

        public virtual GameObjects GameObject { get; set; }
        public virtual MoveTypes MoveType { get; set; }
    }
}
