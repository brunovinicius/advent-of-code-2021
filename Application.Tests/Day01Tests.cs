using Application.Puzzles;
using Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using System;

namespace Application.Tests
{
    public class Day01Tests
    {
        private static readonly string[] TestData = new[] { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" };

        private readonly Mock<IInputFileReadingService> _inputFileReadingServiceMock;
        private readonly IHost _host;

        public Day01Tests()
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
            var result = puzzle.Puzzle1();

            // Assert
            Assert.AreEqual(7, result);
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
            var result = puzzle.Puzzle2();

            // Assert
            Assert.AreEqual(5, result);
        }

        private Day01 GetPuzzleResolver()
        {
            return _host.Services.GetService<Day01>() ?? throw new InvalidOperationException($"Cannot load service: {nameof(Day01)}");
        }
    }
}