using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Houses.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllHousesQueryHandlerTest : IDisposable
    {
        private readonly IHouseRepository mockHouseRepository;

        public GetAllHousesQueryHandlerTest()
        {
            mockHouseRepository = RepositoryMocks.GetHouseRepository();
        }

        [Fact]
        public async Task GetAllHousesQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllHousesQueryHandler(mockHouseRepository);

            // Act
            var result = await handler.Handle(new GetAllHousesQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Houses.Should().NotBeNull();
            result.Houses.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockHouseRepository.ClearReceivedCalls();
        }
    }
}
