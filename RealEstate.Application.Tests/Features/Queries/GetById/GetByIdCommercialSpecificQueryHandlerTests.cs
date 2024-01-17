using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.CommercialSpecifics.Queries;
using RealEstate.Application.Features.CommercialSpecifics.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdCommercialSpecificQueryHandlerTests : IDisposable
    {
        private readonly ICommercialSpecificRepository mockCommercialSpecificRepository;

        public GetByIdCommercialSpecificQueryHandlerTests()
        {
            mockCommercialSpecificRepository = RepositoryMocks.GetCommercialSpecificRepository();
        }

        [Fact]
        public async Task GetByIdCommercialSpecificHandler_WithValidId_ReturnsCommercialSpecific()
        {
            // Arrange
            var category = CommercialCategory.Create("Test Type").Value;
            var exceptedCommercialSpecific = CommercialSpecific.Create("Test Type", category.Id).Value;

            mockCommercialSpecificRepository.FindByIdAsync(exceptedCommercialSpecific.CommercialSpecificId).Returns(Task.FromResult(Result<CommercialSpecific>.Success(exceptedCommercialSpecific)));

            var handler = new GetByIdCommercialSpecificQueryHandler(mockCommercialSpecificRepository);
            // Act
            var result = await handler.Handle(new GetByIdCommercialSpecificQuery(exceptedCommercialSpecific.CommercialSpecificId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new CommercialSpecificDto
            {
                CommercialSpecificId = exceptedCommercialSpecific.CommercialSpecificId,
                SpecificName = exceptedCommercialSpecific.SpecificName,
                CommercialCategoryId = exceptedCommercialSpecific.CommercialCategoryId
            });
        }

        [Fact]
        public async Task GetByIdCommercialSpecificHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockCommercialSpecificRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<CommercialSpecific>.Failure("CommercialSpecific not found")));

            var handler = new GetByIdCommercialSpecificQueryHandler(mockCommercialSpecificRepository);
            // Act
            var result = await handler.Handle(new GetByIdCommercialSpecificQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new CommercialSpecificDto());
        }

        public void Dispose()
        {
            mockCommercialSpecificRepository.ClearReceivedCalls();
        }
    }
}
