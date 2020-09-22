using Life.Core.MapObjects;

namespace Life.Core.Interfaces
{
    public interface IEater
    {
        IEater EaterOwner { get; set; }
        int Id { get; }
        Coordinates Coordinates { get; set; }
        IMap Map { get; }
        int Hp { get; set; }
        void Eat();
    }
}
