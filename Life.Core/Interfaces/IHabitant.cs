using System.Collections.Generic;
using Life.Core.Parameters;

namespace Life.Core.Interfaces
{
    public interface IHabitant
    {
        List<AreaType> Habitat { get; }
    }
}
