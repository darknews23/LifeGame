using Life.Core.Interfaces;
using Life.DAL.DatabaseFirst;
using Life.DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Life.DAL.Extensions
{
    public static class EventRecorderBuilderExtensions
    {
        public static IEventRecorderBuilder AddDatabaseEventRecordingProvider(this IEventRecorderBuilder builder)
        {
            builder.Services
                .AddSingleton<LifeGameDbContext>()
                .AddSingleton<DatabaseEventRecordingProvider>()
                .AddDbEventSavers()
                .AddDbRepositories();
            builder.ProviderTypes.Add(typeof(DatabaseEventRecordingProvider));
            return builder;
        }
    }
}
