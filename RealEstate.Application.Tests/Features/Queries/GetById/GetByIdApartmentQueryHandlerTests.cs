using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Apartments.Queries;
using RealEstate.Application.Features.Apartments.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdApartmentQueryHandlerTests : IDisposable
    {
        private readonly IApartmentRepository mockAparmentRepository;

        public GetByIdApartmentQueryHandlerTests()
        {
            mockAparmentRepository = RepositoryMocks.GetApartmentRepository();
        }

        [Fact]
        public async Task GetByIdApartmentHandler_WithValidId_ReturnsApartment()
        {
            // Arrange
            var address = Address.Create("Test Url", "Test AddressName").Value;
            var partitioning = Partitioning.Create("Test Type").Value;
            var userId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678").ToString();
            var exceptedApartment = Apartment.Create(userId, "Test TitlePost", 1000, address.Id, true, "Test Description", 2, 1, 1, 50, 2000, partitioning.Id).Value;

            mockAparmentRepository.FindByIdAsync(exceptedApartment.BasePostId).Returns(Task.FromResult(Result<Apartment>.Success(exceptedApartment)));

            var handler = new GetByIdApartmentQueryHandler(mockAparmentRepository);
            // Act
            var result = await handler.Handle(new GetByIdApartmentQuery(exceptedApartment.BasePostId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new ApartmentDto
            {
                BasePostId = exceptedApartment.BasePostId,
                UserId = exceptedApartment.UserId,
                TitlePost = exceptedApartment.TitlePost,
                Price = exceptedApartment.Price,
                AddressId = exceptedApartment.AddressId,
                OfferType = exceptedApartment.OfferType,
                Description = exceptedApartment.Description,
                RoomCount = exceptedApartment.RoomCount,
                Comfort = exceptedApartment.Comfort,
                Floor = exceptedApartment.Floor,
                UsefulSurface = exceptedApartment.UsefulSurface,
                BuildYear = exceptedApartment.BuildYear,
                PartitioningId = exceptedApartment.PartitioningId
            });
        }

        [Fact]
        public async Task GetByIdApartmentHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockAparmentRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<Apartment>.Failure("Apartment not found")));

            var handler = new GetByIdApartmentQueryHandler(mockAparmentRepository);
            // Act
            var result = await handler.Handle(new GetByIdApartmentQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new ApartmentDto());
        }

        public void Dispose()
        {
            mockAparmentRepository.ClearReceivedCalls();
        }

    }
}
