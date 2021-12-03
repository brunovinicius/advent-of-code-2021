using Application.Puzzles;
using Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using System;

namespace Application.Tests
{
    public class Day02Tests
    {
        private static readonly string[] TestData = new[] {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };

        private readonly Mock<IInputFileReadingService> _inputFileReadingServiceMock;
        private readonly IHost _host;

        public Day02Tests()
        {
            _inputFileReadingServiceMock = new Mock<IInputFileReadingService>();

            var hostBuilder = new HostBuilder()
                .ConfigureServices(services =>
                {
                    services
                        .AddApplication()
                        .AddFileReadingIntegration()
                        .AddSingleton(_inputFileReadingServiceMock.Object);
                });

            _host = hostBuilder.Build();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Ignore("Requiremente updated. No longer a valid test")]
        public void Puzzle01Test()
        {
            // Arrange
            _inputFileReadingServiceMock
                .Setup(
                    m => m.ReadLines(It.IsAny<string>())
                )
                .Returns(TestData)
                .Verifiable();

            // Act
            var puzzle = GetPuzzleResolver();
            var result = puzzle.Resolve();

            // Assert
            Assert.AreEqual(150, result);
        }

        [Test]
        public void Puzzle02Test()
        {
            // Arrange
            _inputFileReadingServiceMock
                .Setup(
                    m => m.ReadLines(It.IsAny<string>())
                )
                .Returns(TestData)
                .Verifiable();

            // Act
            var puzzle = GetPuzzleResolver();
            var result = puzzle.Resolve();

            // Assert
            Assert.AreEqual(900, result);
        }

        private Day02 GetPuzzleResolver()
        {
            return _host.Services.GetService<Day02>() ?? throw new InvalidOperationException($"Cannot load service: {nameof(Day01)}");
        }
    }
}