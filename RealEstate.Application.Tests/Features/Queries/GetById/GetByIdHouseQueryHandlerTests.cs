using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Houses.Queries;
using RealEstate.Application.Features.Houses.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdHouseQueryHandlerTests : IDisposable
    {
        private readonly IHouseRepository mockHouseRepository;

        public GetByIdHouseQueryHandlerTests()
        {
            mockHouseRepository = RepositoryMocks.GetHouseRepository();
        }

        [Fact]
        public async Task GetByIdHouseHandler_WithValidId_ReturnsHouse()
        {
            // Arrange
            var address = Address.Create("Test Url", "Test AddressName").Value;
            var houseType = HouseType.Create("Test Type").Value;

            var userId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678").ToString();
            
            var exceptedHouse = House.Create(userId, "Test TitlePost", 1000, address.Id, true, "Test Description", 1, 1, 1, 1, 2000, houseType.Id).Value;

            mockHouseRepository.FindByIdAsync(exceptedHouse.BasePostId).Returns(Task.FromResult(Result<House>.Success(exceptedHouse)));

            var handler = new GetByIdHouseQueryHandler(mockHouseRepository);
            // Act
            var result = await handler.Handle(new GetByIdHouseQuery(exceptedHouse.BasePostId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new HouseDto
            {
                BasePostId = exceptedHouse.BasePostId,
                UserId = exceptedHouse.UserId,
                TitlePost = exceptedHouse.TitlePost,
                Price = exceptedHouse.Price,
                AddressId = exceptedHouse.AddressId,
                OfferType = exceptedHouse.OfferType,
                Description = exceptedHouse.Description,
                RoomCount = exceptedHouse.RoomCount,
                FloorCount = exceptedHouse.FloorCount,
                LotArea = exceptedHouse.LotArea,
                BuildYear = exceptedHouse.BuildYear,
                HouseTypeId = exceptedHouse.HouseTypeId,
                UsefulSurface = exceptedHouse.UsefulSurface
            });
        }

        [Fact]
        public async Task GetByIdHouseHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockHouseRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<House>.Failure("House not found")));

            var handler = new GetByIdHouseQueryHandler(mockHouseRepository);
            // Act
            var result = await handler.Handle(new GetByIdHouseQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new HouseDto());
        }

        public void Dispose()
        {
            mockHouseRepository.ClearReceivedCalls();
        }
    }
}
