using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.CommercialCategories.Commands.DeleteCommercialCategory;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteCommercialCategoryCommandHandlerTests : IDisposable
    {
        private readonly ICommercialCategoryRepository mockRepository;
        private readonly DeleteCommercialCategoryHandler handler;
        private readonly CommercialCategory mockCommercialCategory;

        public DeleteCommercialCategoryCommandHandlerTests()
        {
            mockCommercialCategory = CommercialCategory.Create("Test CommercialCategory Name").Value;
            mockRepository = RepositoryMocks.GetCommercialCategoryRepository();
            handler = new DeleteCommercialCategoryHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteCommercialCategoryCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockCommercialCategory.Id).Returns(Result<CommercialCategory>.Success(mockCommercialCategory));

            // Act
            var result = await handler.Handle(new DeleteCommercialCategory { Id = mockCommercialCategory.Id }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteCommercialCategoryCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockCommercialCategory.Id).Returns(Result<CommercialCategory>.Failure("CommercialCategory not found"));

            // Act
            var result = await handler.Handle(new DeleteCommercialCategory { Id = mockCommercialCategory.Id }, CancellationToken.None);

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
