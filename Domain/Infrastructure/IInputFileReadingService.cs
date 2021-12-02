namespace Domain.Infrastructure
{
    public  interface IInputFileReadingService
    {
        IEnumerable<string> ReadLines(string path);
    }
}
