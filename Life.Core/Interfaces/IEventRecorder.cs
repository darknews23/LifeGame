namespace Life.Core.Interfaces
{
    public interface IEventRecorder
    {
        void Record(IEvent eventObj);
        void UpdateGameSessionsState(IGameSessionState state, int stepNumber);
        void Subscribe(IEventRecordingProvider provider);
        void Unsubscribe(IEventRecordingProvider provider);
    }
}
