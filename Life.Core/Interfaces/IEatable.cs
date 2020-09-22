namespace Life.Core.Interfaces
{
    public interface IEatable
    {
        IEatable EatableOwner { get; set; }
        int Id { get; }
        int BeingEatenDamage { get; }
        bool IsFullyEatable { get; }
        int Hp { get; set; }
        int GetEaten();
    }
}
