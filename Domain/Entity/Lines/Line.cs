namespace Domain.Entity.Lines
{
    public class Line
    {
        private readonly Point _start;
        private readonly Point _end;
        private readonly List<Point> _points;

        public IList<Point> Points { get => _points; }
        public bool IsDiagonal { get => _start.X != _end.X && _start.Y != _end.Y; }

        public Line(Point start, Point end)
        {
            _start = start;
            _end = end;
            _points = new List<Point>();

            if (start.Equals(end))
            {
                _points.Add(start);
                return;
            }

            var xDistance = end.X - start.X;
            var yDistance = end.Y - start.Y;
            
            var maxDistance = Math.Max(Math.Abs(xDistance), Math.Abs(yDistance));

            var xIncrement = xDistance / maxDistance;
            var yIncrement = yDistance / maxDistance;
            
            var x = (double)start.X;
            var y = (double)start.Y;
            var last = _start;
            
            _points.Add(last);

            do
            {
                x += xIncrement;
                y += yIncrement;

                last = new Point()
                {
                    X = (int)Math.Floor(x),
                    Y = (int)Math.Floor(y)
                };

                _points.Add(last);

            } while (!end.Equals(last));
        }
    }
}
