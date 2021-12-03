using Domain.Entity;
using Domain.Infrastructure;
using Domain.SubmarineControls;

namespace Application.Puzzles
{
    public class Day02
    {
        private const string FilePath = "C:\\advent-of-code-inputs\\day-02-input.txt";

        private readonly IInputFileReadingService _inputFileReadingService;

        public Day02(IInputFileReadingService inputFileReadingService)
        {
            _inputFileReadingService = inputFileReadingService;
        }

        public int Resolve()
        {
            var rawCommands = GetCommands(FilePath);

            var factory = new SubmatineCommandFactory();
            var commands = rawCommands
                .Select(raw => factory.CreateFromRawCommand(raw))
                .ToList();

            var submarine = new Submarine();
            new SubmarineCommandsExecutor(submarine)
                .ExecuteCommands(commands);

            return submarine.Odometer * submarine.Depth;
        }

        private IEnumerable<RawCommand> GetCommands(string fileName)
        {
            return _inputFileReadingService
                .ReadLines(FilePath)
                .Select(line => line.Split(" "))
                .Select(line => new RawCommand() { Command = line[0], Distance = int.Parse(line[1]) });
        }
    }
}
