using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.BasePosts.Queries;
using RealEstate.Application.Features.BasePosts.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdBasePostQueryHandlerTests : IDisposable
    {
        private readonly IBasePostRepository mockBasePostRepository;

        public GetByIdBasePostQueryHandlerTests()
        {
            mockBasePostRepository = RepositoryMocks.GetBasePostRepository();
        }

        [Fact]
        public async Task GetByIdBasePostHandler_WithValidId_ReturnsBasePost()
        {
            // Arrange
            var address = Address.Create("Test Url", "Test AddressName").Value;
            var userId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678").ToString();
            var exceptedBasePost = BasePost.Create(userId, "Test TitlePost", 1000, address.Id, true, "Test Description").Value;

            mockBasePostRepository.FindByIdAsync(exceptedBasePost.BasePostId).Returns(Task.FromResult(Result<BasePost>.Success(exceptedBasePost)));

            var handler = new GetByIdBasePostQueryHandler(mockBasePostRepository);
            // Act
            var result = await handler.Handle(new GetByIdBasePostQuery(exceptedBasePost.BasePostId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new BasePostDto
            {
                BasePostId = exceptedBasePost.BasePostId,
                UserId = exceptedBasePost.UserId,
                TitlePost = exceptedBasePost.TitlePost,
                Price = exceptedBasePost.Price,
                AddressId = exceptedBasePost.AddressId,
                OfferType = exceptedBasePost.OfferType,
                Description = exceptedBasePost.Description
            });
        }

        [Fact]
        public async Task GetByIdBasePostHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockBasePostRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<BasePost>.Failure("BasePost not found")));

            var handler = new GetByIdBasePostQueryHandler(mockBasePostRepository);
            // Act
            var result = await handler.Handle(new GetByIdBasePostQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new BasePostDto());
        }

        public void Dispose()
        {
            mockBasePostRepository.ClearReceivedCalls();
        }
    }
}
