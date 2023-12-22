using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.HouseTypes.Commands.DeleteHouseType;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteHouseTypeCommandHandlerTests : IDisposable
    {
        private readonly IHouseTypeRepository mockRepository;
        private readonly DeleteHouseTypeHandler handler;
        private readonly HouseType mockHouseType;

        public DeleteHouseTypeCommandHandlerTests()
        {
            mockHouseType = HouseType.Create("Test HouseType").Value;
            
            mockRepository = RepositoryMocks.GetHouseTypeRepository();
            handler = new DeleteHouseTypeHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteHouseTypeCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockHouseType.Id).Returns(Result<HouseType>.Success(mockHouseType));

            // Act
            var result = await handler.Handle(new DeleteHouseType { Id = mockHouseType.Id }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteHouseTypeCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockHouseType.Id).Returns(Result<HouseType>.Failure("HouseType not found"));

            // Act
            var result = await handler.Handle(new DeleteHouseType { Id = mockHouseType.Id}, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
