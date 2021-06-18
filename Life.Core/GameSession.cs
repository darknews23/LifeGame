using System;
using System.Threading;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Life.Core.Parameters;
using Microsoft.Extensions.Logging;

namespace Life.Core
{
    public class GameSession : IGameSessionState
    {
        private static int _stepCount;
        private static int _gameObjectId = 1;
        private static int _maxStep;
        private readonly MapGenerator _mapGenerator;
        private readonly MapSeeder _mapSeeder;
        private readonly MapIterator _mapIterator;
        private readonly ILogger _logger;
        private readonly IEventRecorder _eventRecorder;
        private readonly NewGameSessionEvent _newGameSessionEvent;
        private readonly NewStepEvent _newStepEvent;
        public Guid SessionId { get; }
        public static int GetGameObjectId => _gameObjectId++;
        public static GameStatus GameStatus { get; private set; }
        public static readonly Random Random = new Random(DateTime.Now.Millisecond);
        public IMap Map { get; }

        public static int StepCount
        {
            get => _stepCount;
            private set
            {
                _stepCount = value;
                if (_stepCount == _maxStep)
                {
                    GameStatus = GameStatus.Finished;
                }
            }
        }

        public GameSession(IMap map, MapGenerator mapGenerator, MapSeeder mapSeeder, MapIterator mapIterator,
            ILoggerFactory loggerFactory, IEventRecorder eventRecorder, NewGameSessionEvent newGameSessionEvent, NewStepEvent newStepEvent)
        {
            SessionId = Guid.NewGuid();
            Map = map;
            _logger = loggerFactory.CreateLogger<GameSession>();
            _eventRecorder = eventRecorder;
            _newGameSessionEvent = newGameSessionEvent;
            _newStepEvent = newStepEvent;
            _newStepEvent = newStepEvent;
            _mapGenerator = mapGenerator;
            _mapSeeder = mapSeeder;
            _mapIterator = mapIterator;
            StepCount = 0;
        }

        public void Initialize(int x, int y, int maxStep)
        {
            Map.WorldDimensions = new Coordinates(x,y);
            _maxStep = maxStep+1; //так как начинаем с 1 хода, а не с 0

            GameStatus = GameStatus.Active;

            _newGameSessionEvent.SessionId = SessionId;
            _newGameSessionEvent.SessionStatus = GameStatus;
            _eventRecorder.Record(_newGameSessionEvent);

            _newStepEvent.StepNumber = StepCount;
            _newStepEvent.Tiles = Map.Tiles;
            _newStepEvent.GameObjects = Map.GameObjects;

            _eventRecorder.Record(_newStepEvent);

            _mapGenerator.Generate();
            _mapSeeder.Generate();
            Map.UpdateGameObjectsAndTiles();

            StepCount++;
            while (GameStatus == GameStatus.Active)
            {
                TakeNextStep();
            }
        }

        private void TakeNextStep()
        {
            _newStepEvent.StepNumber = StepCount;

            _eventRecorder.Record(_newStepEvent); 

            _eventRecorder.UpdateGameSessionsState(this, StepCount);

            _logger.LogInformation($"Step number = {StepCount}:\n");

            _mapIterator.TakeNextStep();
            
            Thread.Sleep(500);
            StepCount++;
        }

    }
}
