using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SortingStrategy.Controllers;
using SortingStrategy.Requests;
using SortingStrategy.Services.Interfaces;
using Xunit;

namespace SortingStrategy.Tests
{
    public class SortingControllerTests
    {
        #region Property
        public Mock<IFileService> mock = new Mock<IFileService>();
        public Mock<ILogger<SortingController>> mockLogger = new Mock<ILogger<SortingController>>();

        #endregion

        [Fact]
        public async void LoadFileThrowsExceptions_Returns_BadRequest()
        {
            mock.Setup(p => p.LoadFile("result.txt")).Throws(new System.Exception());

            SortingController sortingController = new SortingController(mockLogger.Object, mock.Object);
            BadRequestObjectResult result = (BadRequestObjectResult)sortingController.LoadFile();
            Assert.Equal(result.StatusCode, 400);
        }

        [Fact]
        public async void LoadFileReturnsIncorrectData_Returns_BadRequest()
        {
            mock.Setup(p => p.LoadFile("result.txt")).Returns("content");

            SortingController sortingController = new SortingController(mockLogger.Object, mock.Object);
            BadRequestObjectResult result = (BadRequestObjectResult)sortingController.LoadFile();
            Assert.Equal(result.StatusCode, 400);
        }

        [Fact]
        public async void LoadFileReturnsCorrectData_Returns_Ok()
        {
            mock.Setup(p => p.LoadFile("result.txt")).Returns("1,2,3");

            SortingController sortingController = new SortingController(mockLogger.Object, mock.Object);
            OkObjectResult result = (OkObjectResult)sortingController.LoadFile();
            Assert.Equal(result.StatusCode, 200);
        }

        [Fact]
        public async void SortWithEmptyList_Returns_BadRequest()
        {
            SortingController sortingController = new SortingController(mockLogger.Object, mock.Object);
            BadRequestResult result = (BadRequestResult)sortingController.Sort(new SortRequest { List = null });
            Assert.Equal(result.StatusCode, 400);
        }
    }
}