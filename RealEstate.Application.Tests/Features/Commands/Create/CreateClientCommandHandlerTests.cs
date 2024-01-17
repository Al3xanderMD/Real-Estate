using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Categories.Commands.CreateClient;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateClientCommandHandlerTests : IDisposable
    {
        private readonly IClientRepository mockRepository;

        public CreateClientCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetClientRepository();
        }

        [Fact]
        public async Task CreateClientCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var userId = new Guid("b3f3d8f0-5f6d-4b3a-9a1a-0e4b4a8a6c7e");
            var username = "Test Username";
            var clientName = "Test ClientName";
            var clientEmail = "Test ClientEmail";
            var clientPhone = "Test ClientPhone";

            var client = Client.Create(userId,username, clientEmail, clientName, clientPhone);

            var command = new CreateClientCommand
            {
                UserId = userId,
                Username = username,
                Name = clientName,
                Email = clientEmail,
                PhoneNumber = clientPhone
            };

            var handler = new CreateClientCommandHandler(mockRepository);
            //var exceptedResult = Result<Client>.Success(client);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.Client.Should().NotBeNull();
            result.Client.UserId.Should().Be(client.Value.UserId);
            result.Client.Username.Should().Be(client.Value.Username);
            result.Client.Email.Should().Be(client.Value.Email);
            result.Client.Name.Should().Be(client.Value.Name);
            result.Client.PhoneNumber.Should().Be(client.Value.PhoneNumber);
        }

        [Fact]
        public async Task CreateClientCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var userId = new Guid("b3f3d8f0-5f6d-4b3a-9a1a-0e4b4a8a6c7e");
            var username = "";
            var clientName = "Test ClientName";
            var clientEmail = "Test ClientEmail";
            var clientPhone = "Test ClientPhone";

            var client = Client.Create(userId, username, clientEmail, clientName, clientPhone);

            var command = new CreateClientCommand
            {
                UserId = userId,
                Username = username,
                Name = username,
                Email = clientEmail,
                PhoneNumber = clientPhone
            };

            var handler = new CreateClientCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.Client.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
