namespace Life.DAL.CodeFirst.Models
{
    public class GameObjectsSessionState
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int SessionId { get; set; }
        public int InitialHp { get; set; }
        public int? MaxBirth { get; set; }
        public int? BirthTime { get; set; }
        public int? AdultAge { get; set; }
        public bool? IsFullyEatable { get; set; }
        public int? ReceivedDamage { get; set; }

        public virtual Sessions Session { get; set; }
        public virtual GameObjectsTypes Type { get; set; }
    }
}
