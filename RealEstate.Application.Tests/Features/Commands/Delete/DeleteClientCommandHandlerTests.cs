using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Clients.Commands.DeleteClient;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteClientCommandHandlerTests : IDisposable
    {
        private readonly IClientRepository mockRepository;
        private readonly DeleteClientHandler handler;
        private readonly Client mockClient;
        private readonly Guid userId = new Guid("b4c2d9f0-5f6a-4f3a-8f8a-5d4e6a5b7b1e");

        public DeleteClientCommandHandlerTests()
        {
            mockClient = Client.Create(userId, "Test Username", "Test Client Email", "Test Name", "Test Client Phone").Value;
            mockRepository = RepositoryMocks.GetClientRepository();
            handler = new DeleteClientHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteClientCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockClient.UserId).Returns(Result<Client>.Success(mockClient));

            // Act
            var result = await handler.Handle(new DeleteClient { UserId = mockClient.UserId }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteClientCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockClient.UserId).Returns(Result<Client>.Failure("Client not found"));

            // Act
            var result = await handler.Handle(new DeleteClient { UserId = mockClient.UserId }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
