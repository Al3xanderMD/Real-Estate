using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Partitionings.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllPartitioningsQueryHandlerTests : IDisposable
    {
                private readonly IPartitioningRepository mockPartitioningRepository;

        public GetAllPartitioningsQueryHandlerTests()
        {
            mockPartitioningRepository = RepositoryMocks.GetPartitioningRepository();
        }

        [Fact]
        public async Task GetAllPartitioningsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllPartitioningsQueryHandler(mockPartitioningRepository);

            // Act
            var result = await handler.Handle(new GetAllPartitioningsQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Partitionings.Should().NotBeNull();
            result.Partitionings.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockPartitioningRepository.ClearReceivedCalls();
        }
    }
}
