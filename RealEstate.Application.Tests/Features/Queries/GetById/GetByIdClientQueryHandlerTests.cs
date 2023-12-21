using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Clients.Queries;
using RealEstate.Application.Features.Clients.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdClientQueryHandlerTests : IDisposable
    {
        private readonly IClientRepository mockClientRepository;

        public GetByIdClientQueryHandlerTests()
        {
            mockClientRepository = RepositoryMocks.GetClientRepository();
        }

        [Fact]
        public async Task GetByIdClientHandler_WithValidId_ReturnsClient()
        {
            // Arrange
            var userId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");
            var exceptedClient = Client.Create(userId, "Test Username", "Test@email.com", "Test Name", "Test PhoneNumber").Value;

            mockClientRepository.FindByIdAsync(exceptedClient.UserId).Returns(Task.FromResult(Result<Client>.Success(exceptedClient)));

            var handler = new GetByIdClientQueryHandler(mockClientRepository);
            // Act
            var result = await handler.Handle(new GetByIdClientQuery(exceptedClient.UserId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new ClientDto
            {
                UserId = exceptedClient.UserId,
                Username = exceptedClient.Username,
                Email = exceptedClient.Email,
                Name = exceptedClient.Name,
                PhoneNumber = exceptedClient.PhoneNumber
            });
        }

        [Fact]
        public async Task GetByIdClientHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockClientRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<Client>.Failure("Client not found")));

            var handler = new GetByIdClientQueryHandler(mockClientRepository);
            // Act
            var result = await handler.Handle(new GetByIdClientQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new ClientDto());
        }

        public void Dispose()
        {
            mockClientRepository.ClearReceivedCalls();
        }
    }
}
