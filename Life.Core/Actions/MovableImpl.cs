using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Life.Core.Parameters;
using Microsoft.Extensions.Logging;

namespace Life.Core.Actions
{
    public class MovableImpl : Actions, IMovable
    {
        private readonly MovementEvent _movementEvent;
        private readonly IEventRecorder _eventRecorder;
        private readonly ILogger _logger;
        private readonly StringBuilder _stringBuilder;
        private Coordinates _lastSafePlace;
        private Coordinates _intermediatePlace;

        private Dictionary<Direction, Coordinates> DirectionToCoordinates => new Dictionary<Direction, Coordinates>
        {
            {Direction.Up, new Coordinates(0, 1)},
            {Direction.Right, new Coordinates(1, 0)},
            {Direction.Down, new Coordinates(0, -1)},
            {Direction.Left, new Coordinates(-1, 0)},
        };
        private Dictionary<AreaType, List<MoveType>> AreaTypeToMoveTypes => new Dictionary<AreaType, List<MoveType>>
        {
            {AreaType.Land, new List<MoveType> {MoveType.Walk, MoveType.Fly}},
            {AreaType.Water, new List<MoveType> {MoveType.Swim, MoveType.Fly}}
        };
        public IMovable MovableOwner { get; set; }
        public Coordinates Coordinates { get; set; }
        public int Id { get; }
        public IMap Map { get; }
        public List<AreaType> Habitat { get; }
        public Dictionary<MoveType, int> AllowedMoveTypes { get; }
        
        public MovableImpl(ILoggerFactory loggerFactory, MovementEvent movementEvent, IEventRecorder eventRecorder)
        {
            _movementEvent = movementEvent;
            _eventRecorder = eventRecorder;
            _logger = loggerFactory.CreateLogger<MovableImpl>();
            _stringBuilder = new StringBuilder();
        }
        public void Move()
        {

            _stringBuilder.Clear();
            var direction = GetRandomDirection();
            var moveType = GetRandomMoveType();
            _intermediatePlace = MovableOwner.Coordinates;
            _lastSafePlace = MovableOwner.Coordinates;

            _stringBuilder.Append($"{MovableOwner.GetType().Name}({MovableOwner.Id}) moves {direction} " +
                            $"from {MovableOwner.Coordinates.X}:{MovableOwner.Coordinates.Y}");

            string extraInformation = "";
            var distance = 0;
            for (int i = 0; i < MovableOwner.AllowedMoveTypes[moveType]; i++)
            {
                var tileInDirection = GetTileInDirection(direction);
                if (tileInDirection != null)
                {
                    if (AreaTypeToMoveTypes[tileInDirection.AreaType].Contains(moveType))
                    {
                        if (CheckTileForSafety(tileInDirection))
                        {
                            _lastSafePlace = tileInDirection.Coordinates;
                        }

                        _intermediatePlace = tileInDirection.Coordinates;
                        distance++;

                        if (CheckTileForObstacles(tileInDirection))
                        {
                            if (moveType == MoveType.Fly)
                            {
                                continue;
                            }
                            else
                            {
                                extraInformation = " Met an obstacle.";
                                break;
                            }
                        }
                    }
                    else
                    {
                        extraInformation = $" Can't {Enum.GetName(typeof(MoveType), moveType)} in {Enum.GetName(typeof(Direction), direction)}";
                        break;
                    }
                }
                else
                {
                    extraInformation = " Met end of map.";
                    break;
                }
            }
            MovableOwner.Coordinates = _lastSafePlace;
            var defaultEnding = $" to {MovableOwner.Coordinates.X}:{MovableOwner.Coordinates.Y}!";

            _stringBuilder.Append(defaultEnding + extraInformation +"\n");

            _movementEvent.ActorId = MovableOwner.Id;
            _movementEvent.ActorType = MovableOwner.GetType();
            _movementEvent.Direction = direction;
            _movementEvent.Distance = distance;
            _movementEvent.MoveType = moveType;
            _movementEvent.StepNumber = GameSession.StepCount;

            _eventRecorder.Record(_movementEvent);

            _logger.LogInformation(_stringBuilder.ToString());
        }
        private GameTileDto GetTileInDirection(Direction direction) =>
            MovableOwner.Map.Tiles.FirstOrDefault(x =>
                x.Coordinates.Equals(_intermediatePlace.CloneWithOffset(DirectionToCoordinates[direction])));

        private MoveType GetRandomMoveType()
        {
            var moveTypes = MovableOwner.AllowedMoveTypes.Keys.ToList();
            return moveTypes[GameSession.Random.Next(0, moveTypes.Count)];
        }

        private Direction GetRandomDirection() => (Direction) GameSession.Random.Next(0, Enum.GetNames(typeof(Direction)).Length);
        private bool CheckTileForSafety(GameTileDto tileDto) => MovableOwner.Habitat.Contains(tileDto.AreaType);
        private bool CheckTileForObstacles(GameTileDto tileDto) => tileDto.GameObjectsOnTile.OfType<IObstacle>().Any();
    }
}
