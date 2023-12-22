using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.HotelPensions.Commands.DeleteHotelPension;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteHotelPensionCommandHandlerTests : IDisposable
    {
        private readonly IHotelPensionRepository mockRepository;
        private readonly DeleteHotelPensionHandler handler;
        private readonly HotelPension mockHotelPension;
        private readonly IAddressRepository mockAddressRepository;
        private readonly Address mockAddress;
        private readonly string userId = new Guid("b4c2d9f0-5f6a-4f3a-8f8a-5d4e6a5b7b1e").ToString();

        public DeleteHotelPensionCommandHandlerTests()
        {
            mockAddress = Address.Create("Test AddressUrl", "Test AddressName").Value;
            mockAddressRepository = RepositoryMocks.GetAddressRepository();
            mockHotelPension = HotelPension.Create(userId, "Test Title Post", 1, mockAddress.Id, true, "Test Description",1 ,1, 1).Value;
            
            mockRepository = RepositoryMocks.GetHotelPensionRepository();
            handler = new DeleteHotelPensionHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteHotelPensionCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockHotelPension.BasePostId).Returns(Result<HotelPension>.Success(mockHotelPension));

            // Act
            var result = await handler.Handle(new DeleteHotelPension { BasePostId = mockHotelPension.BasePostId }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteHotelPensionCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockHotelPension.BasePostId).Returns(Result<HotelPension>.Failure("HotelPension not found"));

            // Act
            var result = await handler.Handle(new DeleteHotelPension { BasePostId = mockHotelPension.BasePostId}, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
            mockAddressRepository.ClearReceivedCalls();
        }
    }
}
