using Application.Puzzles;
using Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using System;

namespace Application.Tests
{
    public class Day05Tests
    {
        private static readonly string[] TestData = new[] 
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2",
        };

        private readonly Mock<IInputFileReadingService> _inputFileReadingServiceMock;
        private readonly IHost _host;

        public Day05Tests()
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
            Assert.AreEqual(5, result);
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
            var result = puzzle.Resolve2();

            // Assert
            Assert.AreEqual(12, result);
        }

        private Day05 GetPuzzleResolver()
        {
            return _host.Services.GetService<Day05>() ?? throw new InvalidOperationException($"Cannot load service: {nameof(Day05)}");
        }
    }
}