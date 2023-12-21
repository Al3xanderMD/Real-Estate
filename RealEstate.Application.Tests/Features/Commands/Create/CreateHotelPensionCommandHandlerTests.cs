using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.HotelPensions.Commands.CreateHotelPension;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateHotelPensionCommandHandlerTests : IDisposable
    {
        private readonly IHotelPensionRepository mockRepository;

        public CreateHotelPensionCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetHotelPensionRepository();
        }

        [Fact]
        public async Task CreateHotelPensionCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "Test Title";
            var price = 1;
            var offerType = true;
            var description = "Test Description";
            var usefulSurface = 1;
            var roomSurface = 1;
            var roomCount = 1;

            var hotelPension = HotelPension.Create(userId, titlePost, price, address.Id, offerType, description,
                                              usefulSurface, roomSurface, roomCount);

            var command = new CreateHotelPensionCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description,
                UsefulSurface = usefulSurface,
                RoomSurface = roomSurface,
                RoomCount = roomCount
            };
        
            var handler = new CreateHotelPensionCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.HotelPension.Should().NotBeNull();
            result.HotelPension.UserId.Should().Be(hotelPension.Value.UserId);
            result.HotelPension.TitlePost.Should().Be(hotelPension.Value.TitlePost);
            result.HotelPension.Price.Should().Be(hotelPension.Value.Price);
            result.HotelPension.AddressId.Should().Be(hotelPension.Value.AddressId);
            result.HotelPension.OfferType.Should().Be(hotelPension.Value.OfferType);
            result.HotelPension.Description.Should().Be(hotelPension.Value.Description);
            result.HotelPension.UsefulSurface.Should().Be(hotelPension.Value.UsefulSurface);
            result.HotelPension.RoomSurface.Should().Be(hotelPension.Value.RoomSurface);
            result.HotelPension.RoomCount.Should().Be(hotelPension.Value.RoomCount);
        }

        [Fact]
        public async Task CreateHotelPensionCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "";
            var price = 1;
            var offerType = true;
            var description = "Test Description";
            var usefulSurface = 1;
            var roomSurface = 1;
            var roomCount = 1;

            var command = new CreateHotelPensionCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description,
                UsefulSurface = usefulSurface,
                RoomSurface = roomSurface,
                RoomCount = roomCount
            };

            var handler = new CreateHotelPensionCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.HotelPension.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
