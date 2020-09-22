using System;
using System.Collections.Generic;
using Life.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Life.Core.EventRecording
{
    public class EventRecorderBuilder : IEventRecorderBuilder
    {
        public IServiceCollection Services { get; }

        public List<Type> ProviderTypes { get; }
        public EventRecorderBuilder(IServiceCollection services)
        {
            Services = services;
            ProviderTypes = new List<Type>();
        }
    }
}
