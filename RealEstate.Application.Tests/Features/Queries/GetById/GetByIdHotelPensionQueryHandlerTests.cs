using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.HotelPensions.Queries;
using RealEstate.Application.Features.HotelPensions.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdHotelPensionQueryHandlerTests : IDisposable
    {
        private readonly IHotelPensionRepository mockHotelPensionRepository;

        public GetByIdHotelPensionQueryHandlerTests()
        {
            mockHotelPensionRepository = RepositoryMocks.GetHotelPensionRepository();
        }

        [Fact]
        public async Task GetByIdHotelPensionHandler_WithValidId_ReturnsHotelPension()
        {
            // Arrange
            var address = Address.Create("Test Url", "Test AddressName").Value;
            var userId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678").ToString();

            var exceptedHotelPension = HotelPension.Create(userId, "Test TitlePost", 1000, address.Id, true, "Test Description", 1, 1, 1).Value;

            mockHotelPensionRepository.FindByIdAsync(exceptedHotelPension.BasePostId).Returns(Task.FromResult(Result<HotelPension>.Success(exceptedHotelPension)));

            var handler = new GetByIdHotelPensionQueryHandler(mockHotelPensionRepository);
            // Act
            var result = await handler.Handle(new GetByIdHotelPensionQuery(exceptedHotelPension.BasePostId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new HotelPensionDto
            {
                BasePostId = exceptedHotelPension.BasePostId,
                UserId = exceptedHotelPension.UserId,
                TitlePost = exceptedHotelPension.TitlePost,
                Price = exceptedHotelPension.Price,
                AddressId = exceptedHotelPension.AddressId,
                OfferType = exceptedHotelPension.OfferType,
                Description = exceptedHotelPension.Description,
                RoomCount = exceptedHotelPension.RoomCount,
                UsefulSurface = exceptedHotelPension.UsefulSurface,
                RoomSurface = exceptedHotelPension.RoomSurface
            });
        }

        [Fact]
        public async Task GetByIdHotelPensionHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockHotelPensionRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<HotelPension>.Failure("HotelPension not found")));

            var handler = new GetByIdHotelPensionQueryHandler(mockHotelPensionRepository);
            // Act
            var result = await handler.Handle(new GetByIdHotelPensionQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new HotelPensionDto());
        }

        public void Dispose()
        {
            mockHotelPensionRepository.ClearReceivedCalls();
        }
    }
}
