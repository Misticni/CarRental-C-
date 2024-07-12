using Car_Rental.Abstraction;
using CarRental.Dto;
using CarRental.Services.Implementation;
using Moq;
using Xunit;

namespace CarRental.Test
{
    public class ClientServiceTests
    {
        [Fact]
        public async Task GetById_ValidId_ReturnsClient()
        {
            // Arrange
            var mockClientRepository = new Mock<IClientRepository>();
            var mockCarRepository = new Mock<ICarRepository>();
            var clientService = new ClientService(mockClientRepository.Object, mockCarRepository.Object);

            var clientId = 1;
            var expectedClient = new ClientDTO { Id = clientId, FirstName = "John", LastName = "Doe" };
            mockClientRepository.Setup(repo => repo.GetByIdAsync(clientId)).ReturnsAsync(expectedClient);

            // Act
            var result = await clientService.GetByIdAsync(clientId);

            // Assert
            Assert.Equal(expectedClient, result);
        }

        [Fact]
        public async Task Create_ValidClient_ReturnsCreatedClient()
        {
            // Arrange
            var mockClientRepository = new Mock<IClientRepository>();
            var mockCarRepository = new Mock<ICarRepository>();
            var clientService = new ClientService(mockClientRepository.Object, mockCarRepository.Object);

            var newClientDto = new ClientDTO { FirstName = "Alice", LastName = "Smith" };
            var expectedClient = new ClientDTO { Id = 1, FirstName = "Alice", LastName = "Smith" };
            mockClientRepository.Setup(repo => repo.CreateAsync(newClientDto)).ReturnsAsync(expectedClient);

            // Act
            var result = await clientService.CreateAsync(newClientDto);

            // Assert
            Assert.Equal(expectedClient, result);
        }

        [Fact]
        public async Task Delete_ValidId_ReturnsTrue()
        {
            // Arrange
            var mockClientRepository = new Mock<IClientRepository>();
            var mockCarRepository = new Mock<ICarRepository>();
            var clientService = new ClientService(mockClientRepository.Object, mockCarRepository.Object);

            var clientId = 1;
            mockClientRepository.Setup(repo => repo.DeleteAsync(clientId)).ReturnsAsync(true);

            // Act
            var result = await clientService.DeleteAsync(clientId);

            // Assert
            Assert.True(result);
        }
    }
}
