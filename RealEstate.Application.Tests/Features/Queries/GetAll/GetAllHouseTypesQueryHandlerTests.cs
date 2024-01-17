using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.HouseTypes.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllHouseTypesQueryHandlerTests : IDisposable
    {
        private readonly IHouseTypeRepository mockHouseTypeRepository;

        public GetAllHouseTypesQueryHandlerTests()
        {
            mockHouseTypeRepository = RepositoryMocks.GetHouseTypeRepository();
        }

        [Fact]
        public async Task GetAllHouseTypesQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllHouseTypesQueryHandler(mockHouseTypeRepository);

            // Act
            var result = await handler.Handle(new GetAllHouseTypesQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.HouseTypes.Should().NotBeNull();
            result.HouseTypes.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockHouseTypeRepository.ClearReceivedCalls();
        }
    }
}
