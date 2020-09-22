using Life.Core.Parameters;

namespace Life.Core.Interfaces
{
    public interface IGender : IMale, IFemale
    {
        IGender GenderOwner { get; set; }
        GenderType GenderType { get; }
        GenderType GetRandomGender();
    }
}
