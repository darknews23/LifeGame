using System;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Life.Core.Parameters;

namespace Life.Core.Actions
{
    public class GenderImpl : Actions, IGender
    {
        private IFemale _female;
        private IMale _male;
        public Coordinates Coordinates { get; set; }
        public int Id { get; }
        public bool IsPregnant { get; set; }
        public Status Status { get; set; }
        public int BirthTime { get; set; }
        public int MaxBirth { get; set; }
        public int CurrentPregnancyTime { get; set; }
        public IMap Map { get; }
        public IGender GenderOwner { get; set; }
        public GenderType GenderType { get; }

        public IMale MaleImplOwner
        {
            get
            {
                _male.MaleImplOwner ??= GenderOwner;
                return GenderOwner.GenderType == GenderType.Male ? _male : null;
            }
            set => _male = value;
        }

        public IFemale FemaleImplOwner
        {
            get
            {
                _female.FemaleImplOwner ??= GenderOwner;
                return GenderOwner.GenderType == GenderType.Female ? _female : null;
            }
            set => _female = value;
        }
        public GenderImpl(IMale male, IFemale female)
        {
            _male = male;
            _female = female;
        }
        public void InitiateReproduction()
        {
            MaleImplOwner?.InitiateReproduction();
        }

        public GenderType GetRandomGender() => (GenderType) GameSession.Random.Next(1, Enum.GetValues(typeof(GenderType)).Length);

        public void GetPregnant()
        {
            FemaleImplOwner?.GetPregnant();
        }

        public void ProgressPregnancy()
        {
            FemaleImplOwner?.ProgressPregnancy();
        }
    }
}
