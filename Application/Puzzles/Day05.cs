using Domain.Entity;
using Domain.Entity.Bingo;
using Domain.Entity.Lines;
using Domain.Infrastructure;
using Domain.SubmarineControls;
using System.Globalization;

namespace Application.Puzzles
{
    public class Day05
    {
        private const string FilePath = "C:\\advent-of-code-inputs\\day-05-input.txt";

        private readonly IInputFileReadingService _inputFileReadingService;

        public Day05(IInputFileReadingService inputFileReadingService)
        {
            _inputFileReadingService = inputFileReadingService;
        }

        public int Resolve()
        {
            var lines = ReadInput();

            var exceptDiagonalLines = lines.Where(line => !line.IsDiagonal);
            
            return ComputeOverlappingPoints(exceptDiagonalLines);
        }
        public int Resolve2()
        {
            var lines = ReadInput();

            return ComputeOverlappingPoints(lines);
        }

        private static int ComputeOverlappingPoints(IEnumerable<Line> lines)
        {
            return lines
                .SelectMany(line => line.Points)
                .GroupBy(point => point)
                .Where(g => g.Count() > 1)
                .Count();
        }

        private IList<Line> ReadInput()
        {
            return _inputFileReadingService
                .ReadLines(FilePath)
                .Select(l => l.Split(" -> "))
                .Select(pointsRaw => 
                    pointsRaw
                        .Select(s => s.Split(","))
                        .Select(coord => new Point()
                        {
                            X = int.Parse(coord.First()),
                            Y = int.Parse(coord.Last()),
                        })
                )
                .Select(points => new Line(points.First(), points.Last()))
                .ToArray();
        }
    }
}
