using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Commercials.Queries;
using RealEstate.Application.Features.Commercials.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdCommercialQueryHandlerTests : IDisposable
    {
        private readonly ICommercialRepository mockRepository;

        public GetByIdCommercialQueryHandlerTests()
        {
            mockRepository = RepositoryMocks.GetCommercialRepository();
        }

        [Fact]
        public async Task GetByIdCommercialHandler_WithValidId_ReturnsCommercial()
        {
            // Arrange
            var address = Address.Create("Test Url", "Test AddressName").Value;
            var commercialCategory = CommercialCategory.Create("Test Type").Value;
            var commercialSpecific = CommercialSpecific.Create("Test Type", commercialCategory.Id).Value;
            var userId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678").ToString();
            DateTime disponibility = new DateTime(2024, 12, 12);

            var exceptedCommercial = Commercial.Create(userId, "Test TitlePost", 1000, address.Id, true, "Test Description", commercialSpecific.CommercialSpecificId, 2, disponibility).Value;

            mockRepository.FindByIdAsync(exceptedCommercial.BasePostId).Returns(Task.FromResult(Result<Commercial>.Success(exceptedCommercial)));

            var handler = new GetByIdCommercialQueryHandler(mockRepository);
            // Act
            var result = await handler.Handle(new GetByIdCommercialQuery(exceptedCommercial.BasePostId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new CommercialDto
            {
                BasePostId = exceptedCommercial.BasePostId,
                UserId = exceptedCommercial.UserId,
                TitlePost = exceptedCommercial.TitlePost,
                Price = exceptedCommercial.Price,
                AddressId = exceptedCommercial.AddressId,
                OfferType = exceptedCommercial.OfferType,
                Description = exceptedCommercial.Description,
                CommercialSpecificId = exceptedCommercial.CommercialSpecificId,
                UsefulSurface = exceptedCommercial.UsefulSurface,
                Disponibility = exceptedCommercial.Disponibility
            });
        }

        [Fact]
        public async Task GetByIdCommercialHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<Commercial>.Failure("Commercial not found")));

            var handler = new GetByIdCommercialQueryHandler(mockRepository);
            // Act
            var result = await handler.Handle(new GetByIdCommercialQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new CommercialDto());
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
