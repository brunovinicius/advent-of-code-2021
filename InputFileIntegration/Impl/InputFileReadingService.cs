using Domain.Infrastructure;

namespace InputFileIntegration.Impl
{
    internal class InputFileReadingService : IInputFileReadingService
    {
        public IEnumerable<string> ReadLines(string path)
        {
            var reader = new StreamReader(path);

            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != null) 
                    yield return line;
            }
        }
    }
}

