using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.BasePosts.Commands.DeleteBasePost;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteBasePostCommandHandlerTests : IDisposable
    {
        private readonly IBasePostRepository mockRepository;
        private readonly DeleteBasePostHandler handler;
        private readonly BasePost mockBasePost;
        private readonly IAddressRepository mockAddressRepository;
        private readonly Address mockAddress;
        private readonly string userId = new Guid("b4c2d9f0-5f6a-4f3a-8f8a-5d4e6a5b7b1e").ToString();

        public DeleteBasePostCommandHandlerTests()
        {
            mockAddress = Address.Create("Test AddressUrl", "Test AddressName").Value;
            mockAddressRepository = RepositoryMocks.GetAddressRepository();
            mockBasePost = BasePost.Create(userId, "Test Title Post", 1, mockAddress.Id, true, "Test Description").Value;
            mockRepository = RepositoryMocks.GetBasePostRepository();
            handler = new DeleteBasePostHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteBasePostCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockBasePost.BasePostId).Returns(Result<BasePost>.Success(mockBasePost));

            // Act
            var result = await handler.Handle(new DeleteBasePost { BasePostId = mockBasePost.BasePostId }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteBasePostCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockBasePost.BasePostId).Returns(Result<BasePost>.Failure("BasePost not found"));

            // Act
            var result = await handler.Handle(new DeleteBasePost { BasePostId = mockBasePost.BasePostId }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
            mockAddressRepository.ClearReceivedCalls();
        }
    }
}
