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

var puzzleResolver = host.Services.GetRequiredService<Day02>();
Console.WriteLine($"{ puzzleResolver.Resolve() }");
Console.ReadKey();
