using Microsoft.EntityFrameworkCore;
using MovieApp.DataLayer.Services;
using MovieApp.DataLayer;
using Xunit;
using Moq;
using MovieApp.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Controllers;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Tests
{
    public class WordToWordServiceTests
    {
        [Fact]
        public async Task GetWordsAsync_ShouldReturnCorrectResults()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase("TestDatabase") // Use EF's in-memory database
                .Options;

            using var dbContext = new MovieContext(options);

            // Seed data (mimicking the SQL result
            dbContext.WordToWordResults.Add(new WordToWordService.WordToWordResult
            {
                Id = 1,
                Word = "test",
                Frequency = 3
            });
            dbContext.SaveChanges();

            var service = new WordToWordService(dbContext);

            // Act
            var results = await service.GetWordsAsync("test");

            // Assert
            Assert.NotNull(results);
            Assert.Single(results);
            Assert.Equal("test", results[0].Word);
            Assert.Equal(3, results[0].Frequency);

    }

}

    public class WordToWordBusinessServiceTests
    {
        [Fact]
        public async Task GetWordToWordAsync_ShouldReturnResultsFromDataLayer()
        {
            // Arrange
            var mockDataLayer = new Mock<WordToWordService>(null);
            mockDataLayer
                .Setup(s => s.GetWordsAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<WordToWordService.WordToWordResult>
                {
                    new WordToWordService.WordToWordResult { Word = "test", Frequency = 3 }
                });

            var businessService = new WordToWordBusinessService(mockDataLayer.Object);

            // Act
            var results = await businessService.GetWordToWordAsync("test");

            // Assert
            Assert.NotNull(results);
            Assert.Single(results);
            Assert.Equal("test", results[0].Word);
            Assert.Equal(3, results[0].Frequency);
        }
    }

    public class WordToWordControllerTests
    {
        [Fact]
        public async Task GetWords_ShouldReturnOkWithResults()
        {
            // Arrange
            var mockLinkGenerator = new Mock<LinkGenerator>(); // Mock the LinkGenerator
            var mockBusinessLayer = new Mock<WordToWordBusinessService>(null);

            mockBusinessLayer
                .Setup(b => b.GetWordToWordAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<WordToWordService.WordToWordResult>
                {
                    new WordToWordService.WordToWordResult { Id = 1, Word = "test", Frequency = 3 }
                });

            var controller = new WordToWordController(mockBusinessLayer.Object, mockLinkGenerator.Object);

            // Act
            var result = await controller.GetWords("test");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<List<WordToWordService.WordToWordResult>>(okResult.Value);
            Assert.Single(response);
            Assert.Equal("test", response[0].Word);
        }
    }
}
