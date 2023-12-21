using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.LotClassifications.CreateLotClassifications;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateLotClassificationCommandHandlerTests : IDisposable
    {
        private readonly ILotClassificationRepository mockRepository;

        public CreateLotClassificationCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetLotClassificationRepository();
        }

        [Fact]
        public async Task CreateLotClassificationCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var lotClassificationName = "Test LotClassificationName";

            var lotClassification = LotClassification.Create(lotClassificationName);

            var command = new CreateLotClassificationCommand
            {
                Type = lotClassificationName
            };

            var handler = new CreateLotClassificationCommandHandler(mockRepository);
            //var exceptedResult = Result<LotClassification>.Success(lotClassification);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.LotClassification.Should().NotBeNull();
            result.LotClassification.Type.Should().Be(lotClassification.Value.Type);
        }

        [Fact]
        public async Task CreateLotClassificationCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var lotClassificationName = "";

            var lotClassification = LotClassification.Create(lotClassificationName);

            var command = new CreateLotClassificationCommand
            {
                Type = lotClassificationName
            };

            var handler = new CreateLotClassificationCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.LotClassification.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
