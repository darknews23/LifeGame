using System;
using Life.Core.Parameters;

namespace Life.Core.Interfaces
{
    public interface IEvent
    {
        int ActorId { get; set; }
        Type ActorType { get; set; }
        ActionType ActionType { get; set; }
        string GetDescription();
    }
}