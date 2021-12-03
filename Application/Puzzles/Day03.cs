using Domain.Entity;
using Domain.Infrastructure;
using Domain.SubmarineControls;
using System.Globalization;

namespace Application.Puzzles
{
    public class Day03
    {
        private const string FilePath = "C:\\advent-of-code-inputs\\day-03-input.txt";

        private readonly IInputFileReadingService _inputFileReadingService;

        public Day03(IInputFileReadingService inputFileReadingService)
        {
            _inputFileReadingService = inputFileReadingService;
        }

        public int Resolve()
        {
            var lines = _inputFileReadingService
                .ReadLines(FilePath)
                .ToArray();

            var gammaDigits = lines
                .Select(line => line.ToCharArray())
                .SelectMany(digits => digits.Select((c, i) => new { i, c }))
                .Where(t => t.c == '1')
                .GroupBy(t => t.i)
                .OrderBy(g => g.Key)
                .Select(g => g.Count() < lines.Length / 2 ? '0' : '1')
                .ToArray();

            var mask = 0;
            for (var i = 0; i < gammaDigits.Length; i++)
                mask = mask << 1 | 0b1;

            var gammaString = new string(gammaDigits);
            var gammaRate = Convert.ToInt32(gammaString, 2);
            var epsilonRate = ~gammaRate & mask;

            return gammaRate * epsilonRate;
        }

        public int Resolve2()
        {
            var lines = _inputFileReadingService
                .ReadLines(FilePath)
                .ToArray();

            var matrix = lines
                .Select(line => line.ToCharArray())
                .ToList();

            int oxygenGeneratorRatinge = FilterByBitCriteria(matrix, (zeroCount, oneCount) => oneCount >= zeroCount);
            int co2ScrubberRating = FilterByBitCriteria(matrix, (zeroCount, oneCount) => oneCount < zeroCount);

            return oxygenGeneratorRatinge * co2ScrubberRating;
        }

        private static int FilterByBitCriteria(List<char[]> matrix, Func<int, int, bool> criteria)
        {
            var columnIndex = 0;
            while (matrix.Count > 1)
            {
                var groups = matrix
                    .GroupBy(c => c[columnIndex])
                    .OrderBy(c => c.Key)
                    .ToArray();

                var mostFrequentOnColumn =
                    criteria(groups[0].Count(), groups[1].Count()) ? '1' : '0';

                matrix = matrix
                    .Where(c => c[columnIndex] == mostFrequentOnColumn)
                    .ToList();

                columnIndex++;
            }

            var digitsString = new string(matrix.First());

            var mask = 0;
            for (var i = 0; i < digitsString.Length; i++)
                mask = mask << 1 | 0b1;

            return Convert.ToInt32(new string(digitsString), 2);
        }
    }
}
