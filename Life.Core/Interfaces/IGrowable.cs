using Life.Core.Parameters;

namespace Life.Core.Interfaces
{
    public interface IGrowable
    {
        IGrowable GrowableOwner { get; set; }
        int Id { get; }
        int CurrentAge { get; set; }
        bool IsEverGrowing { get; }
        int Hp { get; set; }
        int AdultAge { get; }
        Status Status { get; set; }
        void Grow();
    }
}
