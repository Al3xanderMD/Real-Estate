using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Houses.Commands.DeleteHouse;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteHouseCommandHandlerTests : IDisposable
    {
        private readonly IHouseRepository mockRepository;
        private readonly DeleteHouseHandler handler;
        private readonly House mockHouse;
        private readonly IAddressRepository mockAddressRepository;
        private readonly Address mockAddress;
        private readonly IHouseTypeRepository mockHouseTypeRepository;
        private readonly HouseType mockHouseType;
        private readonly string userId = new Guid("b4c2d9f0-5f6a-4f3a-8f8a-5d4e6a5b7b1e").ToString();

        public DeleteHouseCommandHandlerTests()
        {
            mockAddress = Address.Create("Test AddressUrl", "Test AddressName").Value;
            mockAddressRepository = RepositoryMocks.GetAddressRepository();
            mockHouseType = HouseType.Create("Test HouseType").Value;
            mockHouseTypeRepository = RepositoryMocks.GetHouseTypeRepository();
            mockHouse = House.Create(userId, "Test Title Post", 1, mockAddress.Id, true, "Test Description",1 ,1, 1, 1, 2000, mockHouseType.Id).Value;
            
            mockRepository = RepositoryMocks.GetHouseRepository();
            handler = new DeleteHouseHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteHouseCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockHouse.BasePostId).Returns(Result<House>.Success(mockHouse));

            // Act
            var result = await handler.Handle(new DeleteHouse { BasePostId = mockHouse.BasePostId }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteHouseCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockHouse.BasePostId).Returns(Result<House>.Failure("House not found"));

            // Act
            var result = await handler.Handle(new DeleteHouse { BasePostId = mockHouse.BasePostId}, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
            mockAddressRepository.ClearReceivedCalls();
            mockHouseTypeRepository.ClearReceivedCalls();
        }
    }
}
