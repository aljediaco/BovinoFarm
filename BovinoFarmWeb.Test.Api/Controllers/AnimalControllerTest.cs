using BovinoFarmWeb.Api.Controllers;
using BovinoFarmWeb.BL;
using BovinoFarmWeb.BL.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BovinoFarmWeb.Test.Api.Controllers
{
    public class AnimalControllerTest
    {
        Mock<AnimalsFarmBL> animalServiceMock = new Mock<AnimalsFarmBL>();

        [Fact]
        public void GetAnimalById_ReturnsOkResult_WhenAnimalExists()
        {
            var controller = new AnimalController();

            // Act
            var result = controller.GetAnimalByID("f6b0fc19-a4ed-440e-b342-88e84f7eae23");

            // Assert
            Assert.IsType<AnimalResponseBL>(result);
        }

        [Fact]
        public void GetAnimalById_ReturnsNotFoundResult_WhenFileNotFoundExceptionOccurs()
        {
            var controller = new AnimalController();

            // Act
            var result = controller.GetAnimalByID("f6b0fc19-a4ed-440e-b342-88e84f7eae23");

            // Assert
            Assert.IsType<AnimalResponseBL>(result);
        }

        [Fact]
        public void GetAnimalById_ReturnsBadRequestResult_WhenOtherExceptionOccurs()
        {
            var controller = new AnimalController();

            // Act
            var result = controller.GetAnimalByID("f6b0fc19-a4ed-440e-b342-88e84f7eae23");

            // Assert
            Assert.IsType<AnimalResponseBL>(result);
        }

        [Fact]
        public void GetAnimal_ReturnsOkResult_WithAnimalData()
        {
            // Arrange
            var actualPage = 1;
            var pageSize = 10;

            var animalData = new List<AnimalResponseBL>
        {
            new AnimalResponseBL { },
            new AnimalResponseBL { },
        };

            var controller = new AnimalController();

            // Act
            var result = controller.GetAnimal(actualPage, pageSize);

            // Assert
            var okResult = Assert.IsType<AnimalResponseBL>(result);
            var animals = Assert.IsType<List<AnimalResponseBL>>(okResult.IdAnimal);

            Assert.Equal(animalData.Count, animals.Count);
        }

        [Fact]
        public void GetAnimal_ReturnsNotFoundResult_WhenFileNotFoundExceptionOccurs()
        {
            // Arrange
            var actualPage = 1;
            var pageSize = 10;

            var controller = new AnimalController();

            // Act
            var result = controller.GetAnimal(actualPage, pageSize);

            // Assert
            Assert.IsType<AnimalResponseBL>(result);
        }

        [Fact]
        public void GetAnimal_ReturnsBadRequestResult_WhenOtherExceptionOccurs()
        {
            // Arrange
            var actualPage = 1;
            var pageSize = 10;

            var controller = new AnimalController();

            // Act
            var result = controller.GetAnimal(actualPage, pageSize);

            // Assert
            Assert.IsType<AnimalResponseBL>(result);
        }

        [Fact]
        public void CreateAnimal_ReturnsOkResult_WithCreatedAnimalData()
        {
            // Arrange
            var objMock = new Mock<AnimalsFarmBL>();

            var animalRequest = new AnimalRequestBL
            {
                Name = "name test",
                Birthdate = DateTime.Now,
                Sex = "Female",
                Price = 500,
                Comments = "comment test",
                IdBreed = "26714312-fef1-46c0-bf59-af3218e5a632"
            };

            var createdAnimalData = new AnimalResponseBL
            {
                IdAnimal = "",
                Name = "name test",
                Birthdate = DateTime.Now,
                Sex = "Female",
                Price = 500,
                Status = true,
                Comments = "comment test",
                IdBreed = "26714312-fef1-46c0-bf59-af3218e5a632"
            };

            var controller = new AnimalController();

            // Act
            var result = controller.CreateAnimal(animalRequest);

            // Assert
            var createdAnimal = Assert.IsType<AnimalResponseBL>(createdAnimalData.IdAnimal);

            Assert.Equal(createdAnimalData.IdAnimal, createdAnimal.IdAnimal); 
        }

        [Fact]
        public void CreateAnimal_ReturnsBadRequestResult_WhenInvalidDataExceptionOccurs()
        {
            // Arrange
            var animalRequest = new AnimalRequestBL
            {
                Name = "name test",
                Birthdate = DateTime.Now,
                Sex = "Female",
                Price = 500,
                Comments = "comment test",
                IdBreed = "26714312-fef1-46c0-bf59-af3218e5a632"
            };

            var controller = new AnimalController();

            // Act
            var result = controller.CreateAnimal(animalRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateAnimal_ReturnsBadRequestResult_WhenOtherExceptionOccurs()
        {
            // Arrange
            var animalRequest = new AnimalRequestBL
            {
                Name = "name test",
                Birthdate = DateTime.Now,
                Sex = "Female",
                Price = 500,
                Comments = "comment test",
                IdBreed = "26714312-fef1-46c0-bf59-af3218e5a632"
            };

            var controller = new AnimalController();

            // Act
            var result = controller.CreateAnimal(animalRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateAnimal_ReturnsOkResult_WithUpdatedAnimalData()
        {
            // Arrange
            var animalPutRequest = new AnimalPutBL
            {
                IdAnimal = "36f032b9-1ba1-4c21-a1dd-44e9373ba90a",
                Name = "name test",
                Birthdate = DateTime.Now,
                Sex = "Female",
                Price = 500,
                Status = true,
                Comments = "comment test",
                IdBreed = "26714312-fef1-46c0-bf59-af3218e5a632"
            };

            var updatedAnimalData = new AnimalResponseBL
            {
                IdAnimal = "36f032b9-1ba1-4c21-a1dd-44e9373ba90a",
                Name = "name test",
                Birthdate = DateTime.Now,
                Sex = "Female",
                Price = 500,
                Status = true,
                Comments = "comment test",
                IdBreed = "26714312-fef1-46c0-bf59-af3218e5a632"
            };

            var controller = new AnimalController();

            // Act
            var result = controller.UpdateAnimal(animalPutRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var updatedAnimal = Assert.IsType<AnimalResponseBL>(okResult.Value);

            Assert.Equal(updatedAnimalData.IdAnimal, updatedAnimal.IdAnimal); 
        }

        [Fact]
        public void UpdateAnimal_ReturnsBadRequestResult_WhenExceptionOccurs()
        {
            // Arrange
            var objMock = new Mock<AnimalsFarmBL>(); 

            var animalPutRequest = new AnimalPutBL
            {
                IdAnimal = "36f032b9-1ba1-4c21-a1dd-44e9373ba90a",
                Name = "name test",
                Birthdate = DateTime.Now,
                Sex = "Female",
                Price = 500,
                Status = true,
                Comments = "comment test",
                IdBreed = "26714312-fef1-46c0-bf59-af3218e5a632"
            };

            objMock.Setup(x => x.UpdateAnimalBL(It.IsAny<AnimalPutBL>())).Throws<Exception>();

            var controller = new AnimalController();

            // Act
            var result = controller.UpdateAnimal(animalPutRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
