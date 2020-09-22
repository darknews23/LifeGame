using Life.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Life.ConsoleApp.Extensions
{
    public static class EventRecorderBuilderExtensions
    {
        public static IEventRecorderBuilder AddConsoleEventRecordingSubscriber(this IEventRecorderBuilder builder)
        {
            builder.Services.AddSingleton<ConsoleEventRecordingProvider>();
            builder.ProviderTypes.Add(typeof(ConsoleEventRecordingProvider));
            return builder;
        }
    }
}
