using System;
using Life.ConsoleApp.Extensions;
using Life.Core;
using Life.Core.Interfaces;
using Life.DAL.DatabaseFirst.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Life.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            const int x = 10;
            const int y = 10;
            const int stepCount = 10;
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder
                        .AddFile($@"{Environment.CurrentDirectory}\Logging\LifeGame - {{Date}}.log", LogLevel.Debug))
                .AddLifeGameCore()
                .AddSingleton<IRenderer, ConsoleMapRenderer>()
                .AddEventRecorder(builder => builder
                    .AddConsoleEventRecordingSubscriber()
                    .AddDatabaseEventRecordingProvider())
                .BuildServiceProvider();
            serviceProvider.GetService<GameSession>().Initialize(x, y, stepCount);
        }
    }
}
