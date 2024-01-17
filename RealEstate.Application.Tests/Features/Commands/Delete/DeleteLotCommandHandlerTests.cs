using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Lots.Commands.DeleteLot;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteLotCommandHandlerTests : IDisposable
    {
        private readonly ILotRepository mockRepository;
        private readonly DeleteLotHandler handler;
        private readonly Lot mockLot;
        private readonly IAddressRepository mockAddressRepository;
        private readonly Address mockAddress;
        private readonly ILotClassificationRepository mockLotClassificationRepository;
        private readonly LotClassification mockLotClassification;
        private readonly string userId = new Guid("b4c2d9f0-5f6a-4f3a-8f8a-5d4e6a5b7b1e").ToString();

        public DeleteLotCommandHandlerTests()
        {
            mockAddress = Address.Create("Test AddressUrl", "Test AddressName").Value;
            mockAddressRepository = RepositoryMocks.GetAddressRepository();
            mockLotClassification = LotClassification.Create("Test LotClassification").Value;
            mockLotClassificationRepository = RepositoryMocks.GetLotClassificationRepository();
            mockLot = Lot.Create(userId, "Test Title Post", 1, mockAddress.Id, true, "Test Description",1 ,1, mockLotClassification.Id).Value;
            
            mockRepository = RepositoryMocks.GetLotRepository();
            handler = new DeleteLotHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteLotCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockLot.BasePostId).Returns(Result<Lot>.Success(mockLot));

            // Act
            var result = await handler.Handle(new DeleteLot { BasePostId = mockLot.BasePostId }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteLotCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockLot.BasePostId).Returns(Result<Lot>.Failure("Lot not found"));

            // Act
            var result = await handler.Handle(new DeleteLot { BasePostId = mockLot.BasePostId}, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
            mockAddressRepository.ClearReceivedCalls();
            mockLotClassificationRepository.ClearReceivedCalls();
        }
    }
}
