using Life.Core.MapObjects;
using Life.Core.Parameters;

namespace Life.Core.Interfaces
{
    public interface IFemale
    {
        IFemale FemaleImplOwner { get; set; }
        int Id { get; }
        Coordinates Coordinates { get; set; }
        IMap Map { get; }
        Status Status { get; set; }
        int BirthTime { get; }
        int MaxBirth { get; }
        int CurrentPregnancyTime { get; set; }
        void GetPregnant();
        void ProgressPregnancy();
    }
}
