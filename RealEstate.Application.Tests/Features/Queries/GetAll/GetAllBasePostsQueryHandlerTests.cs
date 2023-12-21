using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.BasePosts.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllBasePostsQueryHandlerTests : IDisposable
    {
        private readonly IBasePostRepository mockBasePostRepository;

        public GetAllBasePostsQueryHandlerTests()
        {
            mockBasePostRepository = RepositoryMocks.GetBasePostRepository();
        }

        [Fact]
        public async Task GetAllBasePostsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllBasePostsQueryHandler(mockBasePostRepository);

            // Act
            var result = await handler.Handle(new GetAllBasePostsQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.BasePosts.Should().NotBeNull();
            result.BasePosts.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockBasePostRepository.ClearReceivedCalls();
        }
    }
}
