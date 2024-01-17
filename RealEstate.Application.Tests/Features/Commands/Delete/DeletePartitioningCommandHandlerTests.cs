using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Partitionings.Commands.DeletePartitioning;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeletePartitioningCommandHandlerTests : IDisposable
    {
        private readonly IPartitioningRepository mockRepository;
        private readonly DeletePartitioningHandler handler;
        private readonly Partitioning mockPartitioning;

        public DeletePartitioningCommandHandlerTests()
        {
            mockPartitioning = Partitioning.Create("Test Partitioning").Value;
            
            mockRepository = RepositoryMocks.GetPartitioningRepository();
            handler = new DeletePartitioningHandler(mockRepository);
        }

        [Fact]
        public async Task DeletePartitioningCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockPartitioning.Id).Returns(Result<Partitioning>.Success(mockPartitioning));

            // Act
            var result = await handler.Handle(new DeletePartitioning { Id = mockPartitioning.Id }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeletePartitioningCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockPartitioning.Id).Returns(Result<Partitioning>.Failure("Partitioning not found"));

            // Act
            var result = await handler.Handle(new DeletePartitioning { Id = mockPartitioning.Id}, CancellationToken.None);

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
