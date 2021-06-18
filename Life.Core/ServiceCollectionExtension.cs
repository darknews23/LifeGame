using System;
using System.Linq;
using Life.Core.EventRecording;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Life.Core
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddLifeGameCore(this IServiceCollection services)
        {
            services
                .AddScoped<IMap, Map>()
                .AddTransient<GameSession>()
                .AddScoped<MapGenerator>()
                .AddScoped<MapSeeder>()
                .AddScoped<MapIterator>()
                .AddTransient<Coordinates>()
                .AddGameObjects()
                .AddActions()
                .AddEvents();
            return services;
        }

        private static IServiceCollection AddGameObjects(this IServiceCollection services)
        {
            MapSeeder.GameObjectTypes.ForEach(type => services.AddTransient(type));
            return services;
        }

        private static IServiceCollection AddActions(this IServiceCollection services)
        {
            
            var list = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsSubclassOf(typeof(Actions.Actions)))
                .ToList();

            //для IMovable соответсвует IMovableImpl
            foreach (var obj in list)
            {
                services.AddTransient(
                    obj.GetInterfaces().First(x => obj.Name.Contains(x.Name.Remove(0,1))), obj);
            }
            
            return services;
        }
        private static IServiceCollection AddEvents(this IServiceCollection services)
        {

            var list = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsSubclassOf(typeof(Event)) && !x.IsAbstract)
                .ToList();


            foreach (var type in list)
            {
                services.AddTransient(type);
            }
            
            return services;
        }
        public static IServiceCollection AddEventRecorder(this IServiceCollection services, Action<IEventRecorderBuilder> builder)
        {
            var eventRecorderBuilder = new EventRecorderBuilder(services);
            builder(eventRecorderBuilder);

            services.AddSingleton<IEventRecorder>(provider =>
            {
                var recorder = new EventRecorder();
                foreach (var type in eventRecorderBuilder.ProviderTypes)
                {
                    recorder.Subscribe((IEventRecordingProvider)provider.GetService(type));
                }
                return recorder;
            });

            return services;
        }
    }
}
