using System;
using Life.Core.Interfaces;
using Life.Core.Parameters;

namespace Life.Core.Events
{
    public abstract class Event : IEvent
    {
        public int ActorId { get; set; }
        public Type ActorType { get; set; }
        public virtual ActionType ActionType { get; set; }
        public virtual string GetDescription()
        {
            var description = $"{ActorType.Name}({ActorId}) совершил действие {Enum.GetName(ActionType.GetType(), ActionType)}";
            return description;
        }
    }
}
