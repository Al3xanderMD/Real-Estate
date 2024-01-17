using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.CommercialSpecifics.Commands.DeleteCommercialSpecific;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteCommercialSpecificCommandHandlerTests : IDisposable
    {
        private readonly ICommercialSpecificRepository mockRepository;
        private readonly DeleteCommercialSpecificHandler handler;
        private readonly CommercialSpecific mockCommercialSpecific;
        private readonly ICommercialCategoryRepository mockCommercialCategoryRepository;
        private readonly CommercialCategory mockCommercialCategory;

        public DeleteCommercialSpecificCommandHandlerTests()
        {
            mockCommercialCategory = CommercialCategory.Create("Test Category").Value;
            mockCommercialCategoryRepository = RepositoryMocks.GetCommercialCategoryRepository();
            mockCommercialSpecific = CommercialSpecific.Create("Test Specific", mockCommercialCategory.Id).Value;
            mockRepository = RepositoryMocks.GetCommercialSpecificRepository();
            handler = new DeleteCommercialSpecificHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteCommercialSpecificCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockCommercialSpecific.CommercialSpecificId).Returns(Result<CommercialSpecific>.Success(mockCommercialSpecific));

            // Act
            var result = await handler.Handle(new DeleteCommercialSpecific { CommercialSpecificId = mockCommercialSpecific.CommercialSpecificId }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteCommercialSpecificCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockCommercialSpecific.CommercialSpecificId).Returns(Result<CommercialSpecific>.Failure("CommercialSpecific not found"));

            // Act
            var result = await handler.Handle(new DeleteCommercialSpecific { CommercialSpecificId = mockCommercialSpecific.CommercialSpecificId }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
            mockCommercialCategoryRepository.ClearReceivedCalls();
        }
    }
}
