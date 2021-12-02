using Domain.Entity;
using Domain.Infrastructure;

namespace Application.Puzzles
{
    public class Day01
    {
        private const string FilePath = "C:\\advent-of-code-inputs\\day-01-puzzle-01-input.txt";

        private readonly IInputFileReadingService _inputFileReadingService;

        public Day01(IInputFileReadingService inputFileReadingService)
        {
            _inputFileReadingService = inputFileReadingService;
        }

        public int Puzzle1()
        {
            var readings = GetReadings(FilePath);

            var count = 0;
            RadarReading? previous = null; 
            foreach (var reading in readings)
            {
                if (previous?.Depth <= reading.Depth)
                    count++;

                previous = reading;
            }

            return count;
        }

        public int Puzzle2()
        {
            var readings = GetReadings(FilePath).ToArray();
            
            var count = 0;
            int? previous = null;
            for (int i = 0; i < readings.Length - 2; i++)
            {
                var slidingWindow = readings[i].Depth
                    + readings[i + 1].Depth
                    + readings[i + 2].Depth;

                if (previous < slidingWindow)
                    count++;

                previous = slidingWindow;
            }

            return count;
        }

        private IEnumerable<RadarReading> GetReadings(string fileName)
        {
            return _inputFileReadingService
                .ReadLines(FilePath)
                .Select(line => int.Parse(line))
                .Select(depth => new RadarReading() { Depth = depth });
        }
    }
}
