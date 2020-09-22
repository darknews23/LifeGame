using Life.Core.Interfaces;
using Life.DAL.DatabaseFirst.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Life.DAL.DatabaseFirst.Extensions
{
    public static class EventRecorderBuilderExtensions
    {
        public static IEventRecorderBuilder AddDatabaseEventRecordingProvider(this IEventRecorderBuilder builder)
        {
            builder.Services
                .AddSingleton<LifeGameDBContext>()
                .AddSingleton<DatabaseEventRecordingProvider>()
                .AddDbEventSavers()
                .AddDbRepositories();
            builder.ProviderTypes.Add(typeof(DatabaseEventRecordingProvider));
            return builder;
        }
    }
}
