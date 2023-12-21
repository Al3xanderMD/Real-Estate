using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Partitionings.Queries;
using RealEstate.Application.Features.Partitionings.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdPartitioningQueryHandlerTests : IDisposable
    {
        private readonly IPartitioningRepository mockPartitioningRepository;

        public GetByIdPartitioningQueryHandlerTests()
        {
            mockPartitioningRepository = RepositoryMocks.GetPartitioningRepository();
        }

        [Fact]
        public async Task GetByIdPartitioningHandlerQuery_WithValidId_ReturnsPartitioning()
        {
            // Arrange
            var exceptedPartitioning = Partitioning.Create("Test Type").Value;

            mockPartitioningRepository.FindByIdAsync(exceptedPartitioning.Id).Returns(Task.FromResult(Result<Partitioning>.Success(exceptedPartitioning)));

            var handler = new GetByIdPartitioningQueryHandler(mockPartitioningRepository);
            // Act
            var result = await handler.Handle(new GetByIdPartitioningQuery(exceptedPartitioning.Id), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new PartitioningsDto
            {
                Id = exceptedPartitioning.Id,
                Type = exceptedPartitioning.Type
            });
        }

        [Fact]
        public async Task GetsByIdPartitioningHandlerQuery_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockPartitioningRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<Partitioning>.Failure("Partitioning not found")));

            var handler = new GetByIdPartitioningQueryHandler(mockPartitioningRepository);
            // Act
            var result = await handler.Handle(new GetByIdPartitioningQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new PartitioningsDto());
        }

        public void Dispose()
        {
            mockPartitioningRepository.ClearReceivedCalls();
        }
    }
}
