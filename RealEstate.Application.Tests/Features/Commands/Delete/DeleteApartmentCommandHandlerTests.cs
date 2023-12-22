using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Apartments.Commands.DeleteApartment;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteApartmentCommandHandlerTests : IDisposable
    {
        private readonly IApartmentRepository mockRepository;
        private readonly DeleteApartmentHandler handler;
        private readonly Apartment mockApartment;
        private readonly IPartitioningRepository mockPartitioningRepository;
        private readonly Partitioning mockPartitioning;
        private readonly IAddressRepository mockAddressRepository;
        private readonly Address mockAddress;
        private readonly string userId = new Guid("b4c2d9f0-5f6a-4f3a-8f8a-5d4e6a5b7b1e").ToString();

        public DeleteApartmentCommandHandlerTests()
        {
            mockPartitioning = Partitioning.Create("Test PartitioningName").Value;
            mockPartitioningRepository = RepositoryMocks.GetPartitioningRepository();
            mockAddress = Address.Create("Test AddressUrl", "Test AddressName").Value;
            mockAddressRepository = RepositoryMocks.GetAddressRepository();
            mockApartment = Apartment.Create(userId, "Test Title Post", 1,mockAddress.Id, true, "Test Description",1 ,1, 1, 1, 2000, mockPartitioning.Id).Value;
            
            mockRepository = RepositoryMocks.GetApartmentRepository();
            handler = new DeleteApartmentHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteApartmentCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockApartment.BasePostId).Returns(Result<Apartment>.Success(mockApartment));

            // Act
            var result = await handler.Handle(new DeleteApartment { BasePostId = mockApartment.BasePostId }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteApartmentCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockApartment.BasePostId).Returns(Result<Apartment>.Failure("Apartment not found"));

            // Act
            var result = await handler.Handle(new DeleteApartment { BasePostId = mockApartment.BasePostId}, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
            mockAddressRepository.ClearReceivedCalls();
            mockPartitioningRepository.ClearReceivedCalls();
        }
    }
}
