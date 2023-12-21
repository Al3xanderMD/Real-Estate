using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Apartments.Commands.CreateApartament;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateApartmentCommandHandlerTests : IDisposable
    {
        private readonly IApartmentRepository mockRepository;

        public CreateApartmentCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetApartmentRepository();
        }

        [Fact]
        public async Task CreateApartmentCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "Test Title";
            var price = 1;
            var offerType = true;
            var description = "Test Description";
            var roomCount = 1;
            var comfort = 1;
            var floor = 1;
            var usefulSurface = 1;
            var buildYear = 2000;
            var partitioning = Partitioning.Create("Test Type").Value;
            
            var apartment = Apartment.Create(userId, titlePost, price, address.Id, offerType, description, roomCount, comfort, floor, usefulSurface, buildYear, partitioning.Id);

            var command = new CreateApartmentCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description,
                RoomCount = roomCount,
                Comfort = comfort,
                Floor = floor,
                UsefulSurface = usefulSurface,
                BuildYear = buildYear,
                PartitioningId = partitioning.Id
            };

            var handler = new CreateApartmentCommandHandler(mockRepository);
            //var exceptedResult = Result<Apartment>.Success(apartment);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.Apartment.Should().NotBeNull();
            result.Apartment.UserId.Should().Be(apartment.Value.UserId);
            result.Apartment.TitlePost.Should().Be(apartment.Value.TitlePost);
            result.Apartment.Price.Should().Be(apartment.Value.Price);
            result.Apartment.AddressId.Should().Be(apartment.Value.AddressId);
            result.Apartment.OfferType.Should().Be(apartment.Value.OfferType);
            result.Apartment.Description.Should().Be(apartment.Value.Description);
            result.Apartment.RoomCount.Should().Be(apartment.Value.RoomCount);
            result.Apartment.Comfort.Should().Be(apartment.Value.Comfort);
            result.Apartment.Floor.Should().Be(apartment.Value.Floor);
            result.Apartment.UsefulSurface.Should().Be(apartment.Value.UsefulSurface);
            result.Apartment.BuildYear.Should().Be(apartment.Value.BuildYear);
            result.Apartment.PartitioningId.Should().Be(apartment.Value.PartitioningId);
        }

        [Fact]
        public async Task CreateApartmentCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "";
            var price = 1;
            var offerType = true;
            var description = "Test Description";
            var roomCount = 1;
            var comfort = 1;
            var floor = 1;
            var usefulSurface = 1;
            var buildYear = 2000;
            var partitioning = Partitioning.Create("Test Type").Value;

            var apartment = Apartment.Create(userId, titlePost, price, address.Id, offerType, description, roomCount, comfort, floor, usefulSurface, buildYear, partitioning.Id);

            var command = new CreateApartmentCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description,
                RoomCount = roomCount,
                Comfort = comfort,
                Floor = floor,
                UsefulSurface = usefulSurface,
                BuildYear = buildYear,
                PartitioningId = partitioning.Id
            };

            var handler = new CreateApartmentCommandHandler(mockRepository);
            //var exceptedResult = Result<Apartment>.Failure("'TitlePost' must not be empty");

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.Apartment.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
