using System.Collections.Generic;
using Life.Core.MapObjects;
using Life.Core.Parameters;

namespace Life.Core.Interfaces
{
    public interface IMovable
    {
        IMovable MovableOwner { get; set; }
        int Id { get; }
        Coordinates Coordinates { get; set; }
        IMap Map { get; }
        List<AreaType> Habitat { get; }
        Dictionary<MoveType, int> AllowedMoveTypes { get; }
        void Move();

    }
}
