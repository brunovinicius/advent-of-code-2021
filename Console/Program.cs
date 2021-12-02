using Application.Puzzles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureServices(services =>
    {
        services
            .AddApplication()
            .AddFileReadingIntegration();
    })
    .Build();

var day01 = host.Services.GetRequiredService<Day01>();
Console.WriteLine($"{ day01?.Puzzle1() }");
Console.WriteLine($"{ day01?.Puzzle2() }");
Console.ReadKey();
