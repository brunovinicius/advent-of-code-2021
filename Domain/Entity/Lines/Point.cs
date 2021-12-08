namespace Domain.Entity.Lines
{
    public class Point
    {
        public int X { get; init; }
        public int Y { get; init; }

        public override bool Equals(object? obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
