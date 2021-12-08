using Application.Puzzles;
using Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using System;

namespace Application.Tests
{
    public class Day04Tests
    {
        private static readonly string[] TestData = new[] 
        {
            "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
            "",
            "22 13 17 11  0",
            " 8  2 23  4 24",
            "21  9 14 16  7",
            " 6 10  3 18  5",
            " 1 12 20 15 19",
            "",
            " 3 15  0  2 22",
            " 9 18 13 17  5",
            "19  8  7 25 23",
            "20 11 10 24  4",
            "14 21 16 12  6",
            "",
            "14 21 17 24  4",
            "10 16 15  9 19",
            "18  8 23 26 20",
            "22 11 13  6  5",
            " 2  0 12  3  7",
        };

        private readonly Mock<IInputFileReadingService> _inputFileReadingServiceMock;
        private readonly IHost _host;

        public Day04Tests()
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
            Assert.AreEqual(4512, result);
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
            Assert.AreEqual(1924, result);
        }

        private Day04 GetPuzzleResolver()
        {
            return _host.Services.GetService<Day04>() ?? throw new InvalidOperationException($"Cannot load service: {nameof(Day04)}");
        }
    }
}