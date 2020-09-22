using System.Collections.Generic;
using Life.Core.Interfaces;

namespace Life.Core.EventRecording
{
    class EventRecorder : IEventRecorder
    {
        private readonly List<IEventRecordingProvider> _providers = new List<IEventRecordingProvider>(); 
        public void Record(IEvent eventObj)
        {
            foreach (var provider in _providers)
            {
                provider.RecordEvent(eventObj);
            }
        }

        public void UpdateGameSessionsState(IGameSessionState state, int stepNumber)
        {
            foreach (var provider in _providers)
            {
                provider.UpdateGameSessionState(state, stepNumber);
            }
        }

        public void Subscribe(IEventRecordingProvider provider)
        {
            _providers.Add(provider);
        }

        public void Unsubscribe(IEventRecordingProvider provider)
        {
            _providers.Remove(provider);
        }
    }
}
