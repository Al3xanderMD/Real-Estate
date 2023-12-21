using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.HouseTypes.Commands.CreateHouseType;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateHouseTypeCommandHandlerTests : IDisposable
    {
        private readonly IHouseTypeRepository mockRepository;

        public CreateHouseTypeCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetHouseTypeRepository();
        }

        [Fact]
        public async Task CreateHouseTypeCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var houseTypeName = "Test HouseTypeName";

            var houseType = HouseType.Create(houseTypeName);

            var command = new CreateHouseTypeCommand
            {
                Type = houseTypeName
            };

            var handler = new CreateHouseTypeCommandHandler(mockRepository);
            //var exceptedResult = Result<HouseType>.Success(houseType);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.HouseType.Should().NotBeNull();
            result.HouseType.Type.Should().Be(houseType.Value.Type);
        }

        [Fact]
        public async Task CreateHouseTypeCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var houseTypeName = "";

            var houseType = HouseType.Create(houseTypeName);

            var command = new CreateHouseTypeCommand
            {
                Type = houseTypeName
            };

            var handler = new CreateHouseTypeCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.HouseType.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
