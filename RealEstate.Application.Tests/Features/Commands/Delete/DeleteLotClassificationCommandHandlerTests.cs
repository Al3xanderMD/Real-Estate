using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.LotClassifications.Command.DeleteLotClassification;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteLotClassificationCommandHandlerTests : IDisposable
    {
        private readonly ILotClassificationRepository mockRepository;
        private readonly DeleteLotClassificationHandler handler;
        private readonly LotClassification mockLotClassification;

        public DeleteLotClassificationCommandHandlerTests()
        {
            mockLotClassification = LotClassification.Create("Test LotClassification").Value;
            
            mockRepository = RepositoryMocks.GetLotClassificationRepository();
            handler = new DeleteLotClassificationHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteLotClassificationCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockLotClassification.Id).Returns(Result<LotClassification>.Success(mockLotClassification));

            // Act
            var result = await handler.Handle(new DeleteLotClassification { Id = mockLotClassification.Id }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteLotClassificationCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockLotClassification.Id).Returns(Result<LotClassification>.Failure("LotClassification not found"));

            // Act
            var result = await handler.Handle(new DeleteLotClassification { Id = mockLotClassification.Id}, CancellationToken.None);

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
