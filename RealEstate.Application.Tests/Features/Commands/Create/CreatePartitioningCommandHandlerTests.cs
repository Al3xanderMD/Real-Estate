using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Partitionings.Commands.CreatePartitioning;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreatePartitioningCommandHandlerTests : IDisposable
    {
        private readonly IPartitioningRepository mockRepository;

        public CreatePartitioningCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetPartitioningRepository();
        }

        [Fact]
        public async Task CreatePartitioningCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var partitioningName = "Test PartitioningName";

            var partitioning = Partitioning.Create(partitioningName);

            var command = new CreatePartitioningCommand
            {
                Type = partitioningName
            };
            
            var handler = new CreatePartitioningCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.Partitioning.Should().NotBeNull();
            result.Partitioning.Type.Should().Be(partitioning.Value.Type);
        }

        [Fact]
        public async Task CreatePartitioningCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var partitioningName = "";

            var partitioning = Partitioning.Create(partitioningName);

            var command = new CreatePartitioningCommand
            {
                Type = partitioningName
            };
            
            var handler = new CreatePartitioningCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.Partitioning.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
