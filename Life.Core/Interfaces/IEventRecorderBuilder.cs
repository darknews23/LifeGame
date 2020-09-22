using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Life.Core.Interfaces
{
    public interface IEventRecorderBuilder
    {
        IServiceCollection Services { get; }
        List<Type> ProviderTypes { get; }
    }
}