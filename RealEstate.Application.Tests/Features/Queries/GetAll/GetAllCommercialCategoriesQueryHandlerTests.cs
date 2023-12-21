using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.CommercialCategories.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllCommercialCategoriesQueryHandlerTests : IDisposable
    {
        private readonly ICommercialCategoryRepository mockCommercialCategoryRepository;

        public GetAllCommercialCategoriesQueryHandlerTests()
        {
            mockCommercialCategoryRepository = RepositoryMocks.GetCommercialCategoryRepository();
        }

        [Fact]
        public async Task GetAllCommercialCategoriesQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllCommercialCategoriesQueryHandler(mockCommercialCategoryRepository);

            // Act
            var result = await handler.Handle(new GetAllCommercialCategoriesQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CommercialCategories.Should().NotBeNull();
            result.CommercialCategories.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockCommercialCategoryRepository.ClearReceivedCalls();
        }
    }
}
