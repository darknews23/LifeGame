using System;
using Life.Core.Interfaces;

namespace Life.ConsoleApp
{
    public class ConsoleEventRecordingProvider : IEventRecordingProvider
    {
        private readonly IRenderer _renderer;

        public void RecordEvent(IEvent eventObj)
        {
            Console.WriteLine(eventObj.GetDescription());
        }

        public void UpdateGameSessionState(IGameSessionState state, int stepNumber)
        {
            _renderer.DrawMap(state, stepNumber);
        }

        public ConsoleEventRecordingProvider(IRenderer renderer)
        {
            _renderer = renderer;
        }
    }
}
