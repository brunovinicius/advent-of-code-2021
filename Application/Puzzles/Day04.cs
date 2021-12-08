using Domain.Entity;
using Domain.Entity.Bingo;
using Domain.Infrastructure;
using Domain.SubmarineControls;
using System.Globalization;

namespace Application.Puzzles
{
    public class Day04
    {
        private const string FilePath = "C:\\advent-of-code-inputs\\day-04-input.txt";

        private readonly IInputFileReadingService _inputFileReadingService;

        public Day04(IInputFileReadingService inputFileReadingService)
        {
            _inputFileReadingService = inputFileReadingService;
        }

        public int Resolve()
        {
            ReadInput(out var drawNumbers, out var boards);

            var game = new BingoGame(boards);
            foreach (var number in drawNumbers)
            {
                var bingoBoards = game.DrawNumber(number);
                if (bingoBoards.Any())
                {
                    var winner = bingoBoards.First();
                    Console.WriteLine($"First Winning Board:\n\n{ winner }");
                    return winner.CalculateBoardPonts();
                }
            }

            throw new InvalidOperationException("WTF is wrong with this input!?");
        }

        public int Resolve2()
        {
            ReadInput(out var drawNumbers, out var boards);

            var game = new BingoGame(boards);
            var winningBoards = new List<BingoBoard>();
            foreach (var number in drawNumbers)
            {
                var bingoBoards = game.DrawNumber(number);

                winningBoards.AddRange(bingoBoards);

                if (winningBoards.Count == boards.Count)
                {
                    var lastWinner = winningBoards.Last();
                    Console.WriteLine($"Last Winning Board:\n\n{ lastWinner }");
                    return lastWinner.CalculateBoardPonts();
                }
            }

            throw new InvalidOperationException("WTF is wrong with this input!?");
        }


        private void ReadInput(out BingoNumber[] drawNumbers, out List<BingoBoard> boards)
        {
            var lines = _inputFileReadingService
                .ReadLines(FilePath)
                .ToArray();

            drawNumbers = lines
                .First()
                .Split(",")
                .Select(n => new BingoNumber() { Value = byte.Parse(n) })
                .ToArray();

            boards = lines
                .Skip(2)
                .Where(l => l != string.Empty)
                .Select(l => l
                    .Trim()
                    .Replace("  ", " ")
                    .Split(" ")
                    .Select(n =>
                    {
                        return new BingoNumber() { Value = byte.Parse(n) };
                    })
                    .ToArray()
                )
                .Chunk(5)
                .Select(matrix => new BingoBoard(matrix))
                .ToList();
        }



    }
}
