using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Houses.Commands.CreateHouse;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateHouseCommandHandlerTests : IDisposable
    {
        private readonly IHouseRepository mockRepository;

        public CreateHouseCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetHouseRepository();
        }

        [Fact]
        public async Task CreateHouseCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "Test Title";
            var price = 1;
            var offerType = true;
            var description = "Test Description";
            var roomCount = 1;
            var floorCount = 1;
            var usefulSurface = 1;
            var lotArea = 1;
            var buildYear = 2000;
            var houseType = HouseType.Create("Test HouseType").Value;

            var house = House.Create(userId, titlePost, price, address.Id, offerType, description,
                                              roomCount, floorCount, usefulSurface, lotArea, buildYear, houseType.Id);

            var command = new CreateHouseCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description,
                RoomCount = roomCount,
                FloorCount = floorCount,
                UsefulSurface = usefulSurface,
                LotArea = lotArea,
                BuildYear = buildYear,
                HouseTypeId = houseType.Id
            };

            var handler = new CreateHouseCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.House.Should().NotBeNull();
            result.House.UserId.Should().Be(house.Value.UserId);
            result.House.TitlePost.Should().Be(house.Value.TitlePost);
            result.House.Price.Should().Be(house.Value.Price);
            result.House.AddressId.Should().Be(house.Value.AddressId);
            result.House.OfferType.Should().Be(house.Value.OfferType);
            result.House.Description.Should().Be(house.Value.Description);
            result.House.RoomCount.Should().Be(house.Value.RoomCount);
            result.House.FloorCount.Should().Be(house.Value.FloorCount);
            result.House.UsefulSurface.Should().Be(house.Value.UsefulSurface);
            result.House.LotArea.Should().Be(house.Value.LotArea);
            result.House.BuildYear.Should().Be(house.Value.BuildYear);
            result.House.HouseTypeId.Should().Be(house.Value.HouseTypeId);
        }

        [Fact]
        public async Task CreateHouseCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "";
            var price = 1;
            var offerType = true;
            var description = "Test Description";
            var roomCount = 1;
            var floorCount = 1;
            var usefulSurface = 1;
            var lotArea = 1;
            var buildYear = 2000;
            var houseType = HouseType.Create("Test HouseType").Value;

            var house = House.Create(userId, titlePost, price, address.Id, offerType, description,
                                                             roomCount, floorCount, usefulSurface, lotArea, buildYear, houseType.Id);

            var command = new CreateHouseCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description,
                RoomCount = roomCount,
                FloorCount = floorCount,
                UsefulSurface = usefulSurface,
                LotArea = lotArea,
                BuildYear = buildYear,
                HouseTypeId = houseType.Id
            };

            var handler = new CreateHouseCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.House.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }

    }
}
