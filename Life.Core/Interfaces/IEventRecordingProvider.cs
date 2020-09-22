namespace Life.Core.Interfaces
{
    public interface IEventRecordingProvider
    {
        void RecordEvent(IEvent eventObj);
        void UpdateGameSessionState(IGameSessionState state, int stepNumber);
    }
}
