using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Categories.Commands.CreateBasePost;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateBasePostCommandHandlerTests : IDisposable
    {
        private readonly IBasePostRepository mockRepository;

        public CreateBasePostCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetBasePostRepository();
        }

        [Fact]
        public async Task CreateBasePostCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "Test Title";
            var price = 1;
            var offerType = true;
            var description = "Test Description";

            var basePost = BasePost.Create(userId, titlePost, price, address.Id, offerType, description);

            
            var command = new CreateBasePostCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description
            };

            var handler = new CreateBasePostCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.BasePost.Should().NotBeNull();
            result.BasePost.UserId.Should().Be(basePost.Value.UserId);
            result.BasePost.TitlePost.Should().Be(basePost.Value.TitlePost);
            result.BasePost.Price.Should().Be(basePost.Value.Price);
            result.BasePost.AddressId.Should().Be(basePost.Value.AddressId);
            result.BasePost.OfferType.Should().Be(basePost.Value.OfferType);
            result.BasePost.Description.Should().Be(basePost.Value.Description);
        }

        [Fact]
        public async Task CreateBasePostCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "";
            var price = 1;
            var offerType = true;
            var description = "Test Description";

            var basePost = BasePost.Create(userId, titlePost, price, address.Id, offerType, description);

            var command = new CreateBasePostCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description
            };

            var handler = new CreateBasePostCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.BasePost.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
