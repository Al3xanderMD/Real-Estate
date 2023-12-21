using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.LotClassifications.Queries;
using RealEstate.Application.Features.LotClassifications.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdLotClassifiationQueryHandlerTests : IDisposable
    {
        private readonly ILotClassificationRepository mockLotClassificationRepository;

        public GetByIdLotClassifiationQueryHandlerTests()
        {
            mockLotClassificationRepository = RepositoryMocks.GetLotClassificationRepository();
        }

        [Fact]
        public async Task GetByIdLotClassificationHandler_WithValidId_ReturnsLotClassification()
        {
            // Arrange
            var exceptedLotClassification = LotClassification.Create("Test Type").Value;

            mockLotClassificationRepository.FindByIdAsync(exceptedLotClassification.Id).Returns(Task.FromResult(Result<LotClassification>.Success(exceptedLotClassification)));

            var handler = new GetByIdLotClassificationQueryHandler(mockLotClassificationRepository);
            // Act
            var result = await handler.Handle(new GetByIdLotClassificationQuery(exceptedLotClassification.Id), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new LotClassificationDto
            {
                Id = exceptedLotClassification.Id,
                Type = exceptedLotClassification.Type
            });
        }

        [Fact]
        public async Task GetByIdLotClassificationHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockLotClassificationRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<LotClassification>.Failure("LotClassification not found")));

            var handler = new GetByIdLotClassificationQueryHandler(mockLotClassificationRepository);
            // Act
            var result = await handler.Handle(new GetByIdLotClassificationQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new LotClassificationDto());
        }

        public void Dispose()
        {
            mockLotClassificationRepository.ClearReceivedCalls();
        }
    }
}
