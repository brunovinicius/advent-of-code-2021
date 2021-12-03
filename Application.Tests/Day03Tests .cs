using Application.Puzzles;
using Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using System;

namespace Application.Tests
{
    public class Day03Tests
    {
        private static readonly string[] TestData = new[] 
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010",
        };

        private readonly Mock<IInputFileReadingService> _inputFileReadingServiceMock;
        private readonly IHost _host;

        public Day03Tests()
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
            Assert.AreEqual(198, result);
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
            Assert.AreEqual(230, result);
        }

        private Day03 GetPuzzleResolver()
        {
            return _host.Services.GetService<Day03>() ?? throw new InvalidOperationException($"Cannot load service: {nameof(Day03)}");
        }
    }
}