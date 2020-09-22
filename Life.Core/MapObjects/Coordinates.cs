namespace Life.Core.MapObjects
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Coordinates coordinates) => (coordinates.X == X && coordinates.Y == Y);

        public Coordinates CloneWithOffset(Coordinates coordinates) => new Coordinates(X+coordinates.X, Y+coordinates.Y);
    }
}
