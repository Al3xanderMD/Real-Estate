using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Lots.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllLotsQueryHandlerTests : IDisposable
    {
        private readonly ILotRepository mockLotRepository;

        public GetAllLotsQueryHandlerTests()
        {
            mockLotRepository = RepositoryMocks.GetLotRepository();
        }

        [Fact]
        public async Task GetAllLotsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllLotsQueryHandler(mockLotRepository);

            // Act
            var result = await handler.Handle(new GetAllLotsQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Lots.Should().NotBeNull();
            result.Lots.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockLotRepository.ClearReceivedCalls();
        }
    }
}
