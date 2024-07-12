using Car_Rental.Abstraction;
using CarRental.Dto;
using CarRental.Services.Implementation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRental.Test
{
    public class CarServiceTests
    {
        [Fact]
        public async Task GetAll_ReturnsAllCars()
        {
            // Arrange
            var mockCarRepository = new Mock<ICarRepository>();
            var carService = new CarService(mockCarRepository.Object);

            var expectedCars = new List<CarDTO>
        {
            new CarDTO { Id = 1, LicensePlate = "ABC123", Model = "Model S", Manufacturer = "Tesla", Year = 2020 },
            new CarDTO { Id = 2, LicensePlate = "DEF456", Model = "Civic", Manufacturer = "Honda", Year = 2018 }
            // Add more cars as needed
        };
            mockCarRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(expectedCars);

            // Act
            var result = await carService.GetAllAsync();

            // Assert
            Assert.Equal(expectedCars, result);
        }

        [Fact]
        public async Task Update_InvalidId_ReturnsNull()
        {
            // Arrange
            var mockCarRepository = new Mock<ICarRepository>();
            var carService = new CarService(mockCarRepository.Object);

            var carId = 1;
            var carDto = new CarDTO { Id = 1, LicensePlate = "ABC123", Model = "Model S", Manufacturer = "Tesla", Year = 2020 };
            mockCarRepository.Setup(repo => repo.UpdateAsync(carId, carDto)).ReturnsAsync(null);

            // Act
            var result = await carService.UpdateAsync(carId, carDto);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Delete_ValidId_ReturnsTrue()
        {
            // Arrange
            var mockCarRepository = new Mock<ICarRepository>();
            var carService = new CarService(mockCarRepository.Object);

            var carId = 1;
            mockCarRepository.Setup(repo => repo.DeleteAsync(carId)).ReturnsAsync(true);

            // Act
            var result = await carService.DeleteAsync(carId);

            // Assert
            Assert.True(result);
        }
    }

}
