using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.CommercialSpecifics.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllCommercialSpecificsQueryHandlerTests : IDisposable
    {
        private readonly ICommercialSpecificRepository mockCommercialSpecificRepository;

        public GetAllCommercialSpecificsQueryHandlerTests()
        {
            mockCommercialSpecificRepository = RepositoryMocks.GetCommercialSpecificRepository();
        }

        [Fact]
        public async Task GetAllCommercialSpecificsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllCommercialSpecificsQueryHandler(mockCommercialSpecificRepository);

            // Act
            var result = await handler.Handle(new GetAllCommercialSpecificsQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.CommercialSpecifics.Should().NotBeNull();
            result.CommercialSpecifics.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockCommercialSpecificRepository.ClearReceivedCalls();
        }
    }
}
