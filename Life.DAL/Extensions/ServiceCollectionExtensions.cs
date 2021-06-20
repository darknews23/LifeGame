using Life.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Life.DAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbEventSavers(this IServiceCollection services)
        {

            var list = DatabaseEventRecordingProvider.EventSaverTypes;


            foreach (var type in list)
            {
                services.AddSingleton(type);
            }

            return services;
        }

        public static IServiceCollection AddDbRepositories(this IServiceCollection services)
        {
            return services
                .AddSingleton<EventsRepo>()
                .AddSingleton<GameObjectsSessionTypesRepo>()
                .AddSingleton<GOStepStartStateRepo>()
                .AddSingleton<SessionPartiallyEatableTypesRepo>()
                .AddSingleton<GameObjectsTypesRepo>()
                .AddSingleton<GameTilesRepo>()
                .AddSingleton<SessionsRepo>()
                .AddSingleton<StepsRepo>()
                .AddSingleton<SessionTypesMoveTypesRepo>();

        }

    }
}
