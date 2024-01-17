using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.CommercialCategories.Queries;
using RealEstate.Application.Features.CommercialCategories.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdCommercialCategoryQueryHandlerTests : IDisposable
    {
        private readonly ICommercialCategoryRepository mockRepository;

        public GetByIdCommercialCategoryQueryHandlerTests()
        {
            mockRepository = RepositoryMocks.GetCommercialCategoryRepository();
        }

        [Fact]
        public async Task GetByIdCommercialCategoryHandler_WithValidId_ReturnsCommercialCategory()
        {
            // Arrange
            var exceptedCommercialCategory = CommercialCategory.Create("Test Type").Value;

            mockRepository.FindByIdAsync(exceptedCommercialCategory.Id).Returns(Task.FromResult(Result<CommercialCategory>.Success(exceptedCommercialCategory)));

            var handler = new GetByIdCommercialCategoryQueryHandler(mockRepository);
            // Act
            var result = await handler.Handle(new GetByIdCommercialCategoryQuery(exceptedCommercialCategory.Id), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new CommercialCategoryDto
            {
                Id = exceptedCommercialCategory.Id,
                CategoryName = exceptedCommercialCategory.CategoryName
            });
        }

        [Fact]
        public async Task GetByIdCommercialCategoryHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<CommercialCategory>.Failure("CommercialCategory not found")));

            var handler = new GetByIdCommercialCategoryQueryHandler(mockRepository);
            // Act
            var result = await handler.Handle(new GetByIdCommercialCategoryQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new CommercialCategoryDto());
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
