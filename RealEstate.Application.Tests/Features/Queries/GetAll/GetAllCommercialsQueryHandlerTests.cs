using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Commercials.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllCommercialsQueryHandlerTests : IDisposable
    {
        private readonly ICommercialRepository mockCommercialRepository;

        public GetAllCommercialsQueryHandlerTests()
        {
            mockCommercialRepository = RepositoryMocks.GetCommercialRepository();
        }

        [Fact]
        public async Task GetAllCommercialsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllCommercialsQueryHandler(mockCommercialRepository);

            // Act
            var result = await handler.Handle(new GetAllCommercialsQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Commercials.Should().NotBeNull();
            result.Commercials.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockCommercialRepository.ClearReceivedCalls();
        }
    }
}
