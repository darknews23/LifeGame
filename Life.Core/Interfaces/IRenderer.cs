namespace Life.Core.Interfaces
{
    public interface IRenderer
    {
        //IMap Map { get; }
        void DrawMap(IGameSessionState gameSessionState, int stepNumber);
    }
}
