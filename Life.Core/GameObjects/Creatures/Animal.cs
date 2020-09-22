using System.Collections.Generic;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.GameObjects.Creatures
{
    abstract class Animal : Creature, IEater, IMovable, IGender
    {
        private readonly IGender _gender;
        private readonly IMovable _movable;
        private readonly IEater _eater;
        private GenderType _genderType;
        public override bool IsEverGrowing => false;
        public abstract Dictionary<MoveType, int> AllowedMoveTypes { get; }
        public abstract int MaxBirth { get; }
        public int CurrentPregnancyTime { get; set; }

        public IGender GenderOwner { get; set; }
        public IMale MaleImplOwner { get; set; }
        public IFemale FemaleImplOwner { get; set; }

        public IMovable MovableOwner { get; set; }

        public GenderType GenderType
        {
            get
            {
                if (_genderType == GenderType.None)
                {
                    _genderType = GetRandomGender();
                }
                return _genderType;
            }
        }

        public IEater EaterOwner { get; set; }
        public bool IsPregnant { get; set; }
        public abstract int BirthTime { get; }

        protected Animal(IMap map, IGrowable growable, IMovable movable, IEater eater, IGender gender,
            DeathEvent deathEvent, IEventRecorder eventRecorder) : base(map, growable, deathEvent, eventRecorder)
        {
            IsPregnant = false;
            _gender = gender;
            _gender.GenderOwner = this;
            _eater = eater;
            _eater.EaterOwner = this;
            _movable = movable;
            _movable.MovableOwner = this;
        }
        public void InitiateReproduction()
        {
            _gender?.InitiateReproduction();
        }


        public void GetPregnant()
        {
            _gender?.GetPregnant();
        }

        public void ProgressPregnancy()
        {
            _gender?.ProgressPregnancy();
        }

        public void Eat()
        {
            _eater?.Eat();
        }
        public void Move()
        {
            _movable?.Move();
        }
        public GenderType GetRandomGender()
        {
            return _gender.GetRandomGender();
        }
    }
}
