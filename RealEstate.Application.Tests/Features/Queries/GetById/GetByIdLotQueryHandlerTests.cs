using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Lots.Queries;
using RealEstate.Application.Features.Lots.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdLotQueryHandlerTests : IDisposable
    {
        private readonly ILotRepository mockLotRepository;

        public GetByIdLotQueryHandlerTests()
        {
            mockLotRepository = RepositoryMocks.GetLotRepository();
        }

        [Fact]
        public async Task GetByIdLotHandler_WithValidId_ReturnsLot()
        {
            // Arrange
            var address = Address.Create("Test Url", "Test AddressName").Value;
            var lotClassification = LotClassification.Create("Test Type").Value;
            var userId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678").ToString();

            var exceptedLot = Lot.Create(userId, "Test TitlePost", 1000, address.Id, true, "Test Description", 1, 1, lotClassification.Id).Value;

            mockLotRepository.FindByIdAsync(exceptedLot.BasePostId).Returns(Task.FromResult(Result<Lot>.Success(exceptedLot)));

            var handler = new GetByIdLotQueryHandler(mockLotRepository);
            // Act
            var result = await handler.Handle(new GetByIdLotQuery(exceptedLot.BasePostId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new LotDto
            {
                BasePostId = exceptedLot.BasePostId,
                UserId = exceptedLot.UserId,
                TitlePost = exceptedLot.TitlePost,
                Price = exceptedLot.Price,
                AddressId = exceptedLot.AddressId,
                OfferType = exceptedLot.OfferType,
                Description = exceptedLot.Description,
                LotArea = exceptedLot.LotArea,
                StreetFrontage = exceptedLot.StreetFrontage,
                LotClassificationId = exceptedLot.LotClassificationId
            });
        }

        [Fact]
        public async Task GetByIdLotHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockLotRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<Lot>.Failure("Lot not found")));

            var handler = new GetByIdLotQueryHandler(mockLotRepository);
            // Act
            var result = await handler.Handle(new GetByIdLotQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new LotDto());
        }

        public void Dispose()
        {
            mockLotRepository.ClearReceivedCalls();
        }
    }
}
