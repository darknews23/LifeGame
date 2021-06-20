using System.Collections.Generic;
using System.Linq;
using System.Text;
using Life.Core.Events;
using Life.Core.GameObjects;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Life.Core.Parameters;
using Microsoft.Extensions.Logging;

namespace Life.Core.Actions
{
    public class FemaleImpl : Actions, IFemale
    {
        private readonly GettingPregnantEvent _gettingPregnantEvent;
        private readonly PregnancyProgressionEvent _pregnancyProgressionEvent;
        private readonly BirthEvent _birthEvent;
        private readonly GameObjectsCreationEvent _gameObjectsCreationEvent;
        private readonly IEventRecorder _eventRecorder;
        public IFemale FemaleImplOwner { get; set; }
        public int Id { get; }
        public Coordinates Coordinates { get; set; }
        public IMap Map { get; }
        public bool IsPregnant { get; set; }
        public Status Status { get; set; }
        public int BirthTime { get; set; }
        public int MaxBirth { get; set; }
        private readonly ILogger _logger;
        private readonly StringBuilder _stringBuilder;

        public int CurrentPregnancyTime { get; set; }
        public FemaleImpl(ILoggerFactory loggerFactory, GettingPregnantEvent gettingPregnantEvent,
            PregnancyProgressionEvent pregnancyProgressionEvent, BirthEvent birthEvent, GameObjectsCreationEvent gameObjectsCreationEvent,
            IEventRecorder eventRecorder)
        {
            _gettingPregnantEvent = gettingPregnantEvent;
            _pregnancyProgressionEvent = pregnancyProgressionEvent;
            _birthEvent = birthEvent;
            _gameObjectsCreationEvent = gameObjectsCreationEvent;
            _eventRecorder = eventRecorder;
            _logger = loggerFactory.CreateLogger<FemaleImpl>();
            _stringBuilder = new StringBuilder();
        }

        public void GetPregnant()
        {
            _stringBuilder.Clear();
            FemaleImplOwner.IsPregnant = true;
            FemaleImplOwner.CurrentPregnancyTime = 0;

            _gettingPregnantEvent.ActorId = FemaleImplOwner.Id;
            _gettingPregnantEvent.ActorType = FemaleImplOwner.GetType();
            _gettingPregnantEvent.StepNumber = GameSession.StepCount;

            _eventRecorder.Record(_gettingPregnantEvent);

            _stringBuilder.Append($"{FemaleImplOwner.GetType().Name}({FemaleImplOwner.Id}) got pregnant.");
            _logger.LogInformation(_stringBuilder.ToString());
        }

        public void ProgressPregnancy()
        {
            if (FemaleImplOwner.IsPregnant)
            {
                _pregnancyProgressionEvent.ActorId = FemaleImplOwner.Id;
                _pregnancyProgressionEvent.ActorType = FemaleImplOwner.GetType();
                _pregnancyProgressionEvent.StepNumber = GameSession.StepCount;

                _eventRecorder.Record(_pregnancyProgressionEvent);
                if (FemaleImplOwner.CurrentPregnancyTime < FemaleImplOwner.BirthTime)
                {
                    FemaleImplOwner.CurrentPregnancyTime++;
                }
                else
                {
                    GiveBirth();
                }
            }
        }
        public void GiveBirth()
        {
            FemaleImplOwner.CurrentPregnancyTime = 0;
            FemaleImplOwner.IsPregnant = false;
            _stringBuilder.Clear();
            var randomBirthNumber = GameSession.Random.Next(1, FemaleImplOwner.MaxBirth + 1);
            _stringBuilder.Append($"{FemaleImplOwner.GetType().Name}({FemaleImplOwner.Id}) gave birth to {randomBirthNumber}.\nCreatures born: ");

            _birthEvent.ActorId = FemaleImplOwner.Id;
            _birthEvent.ActorType = FemaleImplOwner.GetType();
            _birthEvent.StepNumber = GameSession.StepCount;
            _birthEvent.ChildrenId = new List<int>();

            _gameObjectsCreationEvent.GameObjects = new List<BaseGameObject>();
            _gameObjectsCreationEvent.StepNumber = GameSession.StepCount;
            for (int i = 0; i < randomBirthNumber; i++)
            {
                var gameObject = MapSeeder.CreateObject(FemaleImplOwner.GetType(), FemaleImplOwner.Coordinates);
                _birthEvent.ChildrenId.Add(gameObject.Id);

                _gameObjectsCreationEvent.GameObjects.Add(gameObject);

                FemaleImplOwner.Map.GameObjects.Add(gameObject);

                _stringBuilder.Append($"{FemaleImplOwner.Map.GameObjects.Last().GetType().Name}({FemaleImplOwner.Map.GameObjects.Last().Id}) ");
            }

            _eventRecorder.Record(_gameObjectsCreationEvent);
            _eventRecorder.Record(_birthEvent);

            _stringBuilder.Append("\n");
            _logger.LogInformation(_stringBuilder.ToString());
        }
    }
}
