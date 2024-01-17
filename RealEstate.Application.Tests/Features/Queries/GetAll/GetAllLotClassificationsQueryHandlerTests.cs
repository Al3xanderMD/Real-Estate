using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.LotClassifications.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllLotClassificationsQueryHandlerTests : IDisposable
    {
        private readonly ILotClassificationRepository mockLotClassificationRepository;

        public GetAllLotClassificationsQueryHandlerTests()
        {
            mockLotClassificationRepository = RepositoryMocks.GetLotClassificationRepository();
        }

        [Fact]
        public async Task GetAllLotClassificationsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllLotClassificationsQueryHandler(mockLotClassificationRepository);

            // Act
            var result = await handler.Handle(new GetAllLotClassificationsQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.LotClassifications.Should().NotBeNull();
            result.LotClassifications.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockLotClassificationRepository.ClearReceivedCalls();
        }
    }
}
