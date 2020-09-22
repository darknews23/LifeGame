using Life.Core.MapObjects;

namespace Life.Core.Interfaces
{
    public interface IMale
    {
        IMale MaleImplOwner { get; set; }
        int Id { get; }
        Coordinates Coordinates { get; set; }
        IMap Map { get; }
        void InitiateReproduction();
    }
}
