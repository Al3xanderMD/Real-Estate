using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Lots.Commands.CreateLot;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateLotCommandHandlerTests : IDisposable
    {
        private readonly ILotRepository mockRepository;

        public CreateLotCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetLotRepository();
        }

        [Fact]
        public async Task CreateLotCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "Test Title";
            var price = 1;
            var offerType = true;
            var description = "Test Description";
            var lotArea = 1;
            var streetFrontage = 1;
            var lotClassification = LotClassification.Create("Test LotClassification").Value;

            var lot = Lot.Create(userId, titlePost, price, address.Id, offerType, description,
                               lotArea, streetFrontage, lotClassification.Id);

            var command = new CreateLotCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description,
                LotArea = lotArea,
                StreetFrontage = streetFrontage,
                LotClassificationId = lotClassification.Id
            };

            var handler = new CreateLotCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.Lot.Should().NotBeNull();
            result.Lot.UserId.Should().Be(lot.Value.UserId);
            result.Lot.TitlePost.Should().Be(lot.Value.TitlePost);
            result.Lot.Price.Should().Be(lot.Value.Price);
            result.Lot.AddressId.Should().Be(lot.Value.AddressId);
            result.Lot.OfferType.Should().Be(lot.Value.OfferType);
            result.Lot.Description.Should().Be(lot.Value.Description);
            result.Lot.LotArea.Should().Be(lot.Value.LotArea);
            result.Lot.StreetFrontage.Should().Be(lot.Value.StreetFrontage);
            result.Lot.LotClassificationId.Should().Be(lot.Value.LotClassificationId);
        }

        [Fact]
        public async Task CreateLotCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "";
            var price = 1;
            var offerType = true;
            var description = "Test Description";
            var lotArea = 1;
            var streetFrontage = 1;
            var lotClassification = LotClassification.Create("Test LotClassification").Value;

            var command = new CreateLotCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description,
                LotArea = lotArea,
                StreetFrontage = streetFrontage,
                LotClassificationId = lotClassification.Id
            };

            var handler = new CreateLotCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.Lot.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
