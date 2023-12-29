using BovinoFarmWeb.Api.Controllers;
using BovinoFarmWeb.BL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BovinoFarmWeb.Test.Api.Controllers
{
    public class BreedControllerTest
    {
        [Fact]
        public void GetBreedById_ReturnsOkResult_WithBreedData()
        {
            // Arrange
            var breedId = "1abd48e6-fbce-4aa2-97d8-cf6bf8d8cdd9";
            var breedData = new BreedResponseBL
            {
                IdBreed = breedId,
                Name = "test"
            };

            var controller = new BreedController();

            // Act
            var result = controller.GetBreedByID(breedId);

            // Assert
            var okResult = Assert.IsType<BreedResponseBL>(result);
            var breed = Assert.IsType<BreedResponseBL>(okResult.IdBreed);

            Assert.Equal(breedData.IdBreed, breed.IdBreed);
        }

        [Fact]
        public void GetBreedById_ReturnsNotFoundResult_WhenFileNotFoundExceptionOccurs()
        {
            // Arrange
            var breedId = "1abd48e6-fbce-4aa2-97d8-cf6bf8d8cdd9";
            var controller = new BreedController();

            // Act
            var result = controller.GetBreedByID(breedId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetBreedById_ReturnsBadRequestResult_WhenOtherExceptionOccurs()
        {
            // Arrange}
            var breedId = "1abd48e6-fbce-4aa2-97d8-cf6bf8d8cdd9";
            var controller = new BreedController();

            // Act
            var result = controller.GetBreedByID(breedId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public void GetBreed_ReturnsOkResult_WithBreedData()
        {
            // Arrange
            var actualPage = 1;
            var pageSize = 10;

            var BreedData = new List<BreedResponseBL>
        {
            new BreedResponseBL { },
            new BreedResponseBL { },
        };

            var controller = new BreedController();

            // Act
            var result = controller.GetBreed(actualPage, pageSize);

            // Assert
            var okResult = Assert.IsType<BreedResponseBL>(result);
            var Breeds = Assert.IsType<List<BreedResponseBL>>(okResult.IdBreed);

            Assert.Equal(BreedData.Count, Breeds.Count);
        }

        [Fact]
        public void GetBreed_ReturnsNotFoundResult_WhenFileNotFoundExceptionOccurs()
        {
            // Arrange
            var actualPage = 1;
            var pageSize = 10;

            var controller = new BreedController();

            // Act
            var result = controller.GetBreed(actualPage, pageSize);

            // Assert
            Assert.IsType<BreedResponseBL>(result);
        }

        [Fact]
        public void GetBreed_ReturnsBadRequestResult_WhenOtherExceptionOccurs()
        {
            // Arrange
            var actualPage = 1;
            var pageSize = 10;

            var controller = new BreedController();

            // Act
            var result = controller.GetBreed(actualPage, pageSize);

            // Assert
            Assert.IsType<BreedResponseBL>(result);
        }

        [Fact]
        public void CreateBreed_ReturnsOkResult_WithCreatedBreedData()
        {
            // Arrange
            var BreedRequest = new BreedRequestBL
            {
                Name = "name test"
            };

            var createdBreedData = new BreedResponseBL
            {
                IdBreed = "",
                Name = "name test"
            };

            var controller = new BreedController();

            // Act
            var result = controller.CreateBreed(BreedRequest);

            // Assert
            var createdBreed = Assert.IsType<BreedResponseBL>(createdBreedData.IdBreed);

            Assert.Equal(createdBreedData.IdBreed, createdBreed.IdBreed);
        }

        [Fact]
        public void CreateBreed_ReturnsBadRequestResult_WhenInvalidDataExceptionOccurs()
        {
            // Arrange
            var BreedRequest = new BreedRequestBL
            {
                Name = "name test"
            };

            var controller = new BreedController();

            // Act
            var result = controller.CreateBreed(BreedRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateBreed_ReturnsBadRequestResult_WhenOtherExceptionOccurs()
        {
            // Arrange
            var BreedRequest = new BreedRequestBL
            {
                Name = "name test"
            };

            var controller = new BreedController();

            // Act
            var result = controller.CreateBreed(BreedRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateBreed_ReturnsOkResult_WithUpdatedBreedData()
        {
            // Arrange
            var BreedPutRequest = new BreedResponseBL
            {
                IdBreed = "1abd48e6-fbce-4aa2-97d8-cf6bf8d8cdd9",
                Name = "name test"
            };

            var updatedBreedData = new BreedResponseBL
            {
                IdBreed = "1abd48e6-fbce-4aa2-97d8-cf6bf8d8cdd9",
                Name = "name test"
            };

            var controller = new BreedController();

            // Act
            var result = controller.UpdateBreed(BreedPutRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var updatedBreed = Assert.IsType<BreedResponseBL>(okResult.Value);

            Assert.Equal(updatedBreedData.IdBreed, updatedBreed.IdBreed);
        }

        [Fact]
        public void UpdateBreed_ReturnsBadRequestResult_WhenExceptionOccurs()
        {
            // Arrange
            var BreedPutRequest = new BreedResponseBL
            {
                IdBreed = "1abd48e6-fbce-4aa2-97d8-cf6bf8d8cdd9",
                Name = "name test"
            };

            var controller = new BreedController();

            // Act
            var result = controller.UpdateBreed(BreedPutRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
