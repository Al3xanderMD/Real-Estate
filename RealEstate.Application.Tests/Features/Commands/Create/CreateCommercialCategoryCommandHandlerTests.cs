using FluentAssertions;
using RealEstate.Application.Features.CommercialCategories.Commands.CreateCommercialCategory;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateCommercialCategoryCommandHandlerTests : IDisposable
    {
        private readonly ICommercialCategoryRepository mockRepository;

        public CreateCommercialCategoryCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetCommercialCategoryRepository();
        }

        [Fact]
        public async Task CreateCommercialCategoryCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var commercialCategoryName = "Test CommercialCategoryName";

            var commercialCategory = CommercialCategory.Create(commercialCategoryName);

            var command = new CreateCommercialCategoryCommand
            {
                CategoryName = commercialCategoryName
            };

            var handler = new CreateCommercialCategoryCommandHandler(mockRepository);
            //var exceptedResult = Result<CommercialCategory>.Success(commercialCategory);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.CommercialCategory.Should().NotBeNull();
            result.CommercialCategory.CategoryName.Should().Be(commercialCategory.Value.CategoryName);
        }

        [Fact]
        public async Task CreateCommercialCategoryCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var commercialCategoryName = "";

            var commercialCategory = CommercialCategory.Create(commercialCategoryName);

            var command = new CreateCommercialCategoryCommand
            {
                CategoryName = commercialCategoryName
            };

            var handler = new CreateCommercialCategoryCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.CommercialCategory.Should().BeNull();
        }

        public void Dispose()
        {
        }
    }   
}
