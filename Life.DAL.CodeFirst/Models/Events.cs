namespace Life.DAL.CodeFirst.Models
{
    public class Events
    {
        public int Id { get; set; }
        public int ActionId { get; set; }
        public int GameObjectId1 { get; set; }
        public int? GameObjectId2 { get; set; }
        public bool? BecameAdult { get; set; }
        public int? HpChange { get; set; }
        public int? DirectionId { get; set; }
        public int? Distance { get; set; }
        public int? MoveTypeId { get; set; }

        public virtual Actions Action { get; set; }
        public virtual GameObjectsStepState GameObjectId1Navigation { get; set; }
        public virtual MoveTypes IdNavigation { get; set; }
    }
}
