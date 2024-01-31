using Microsoft.Extensions.Logging;
using Moq;
using service.transport.business;
using service.transport.common.Entity;
using service.transport.data;

[TestFixture]
public class TransportationServiceTests
{
    [Test]
    public async Task DeleteTransportationOptionAsync_DeletesOption_ReturnsTrue()
    {
        // Arrange
        var repositoryMock = new Mock<ITransportRepo>();
        repositoryMock.Setup(repo => repo.DeleteTransportationOptionAsync(It.IsAny<int>())).ReturnsAsync(true);

        var loggerMock = new Mock<ILogger<TransportService>>();

        var service = new TransportService(repositoryMock.Object, loggerMock.Object);

        // Act
        var result = await service.DeleteTransportationOptionAsync(1);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public async Task DeleteTransportationOptionAsync_NotFound_ReturnsFalse()
    {
        // Arrange
        var repositoryMock = new Mock<ITransportRepo>();
        repositoryMock.Setup(repo => repo.DeleteTransportationOptionAsync(It.IsAny<int>())).ReturnsAsync(false);

        var loggerMock = new Mock<ILogger<TransportService>>();

        var service = new TransportService(repositoryMock.Object, loggerMock.Object);

        // Act
        var result = await service.DeleteTransportationOptionAsync(1);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task UpdateTransportationOptionAsync_UpdatesOption_ReturnsUpdatedOption()
    {
        // Arrange
        var repositoryMock = new Mock<ITransportRepo>();
        repositoryMock.Setup(repo => repo.UpdateTransportationOptionAsync(It.IsAny<int>(), It.IsAny<TransportationOption>()))
                      .ReturnsAsync((int id, TransportationOption option) => option);

        var loggerMock = new Mock<ILogger<TransportService>>();

        var service = new TransportService(repositoryMock.Object, loggerMock.Object);

        var updatedOption = new TransportationOption { Id = 1, Description = "Updated Description" };

        // Act
        var result = await service.UpdateTransportationOptionAsync(1, updatedOption);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(updatedOption.Id, result.Id);
        Assert.AreEqual(updatedOption.Description, result.Description);
    }
}
