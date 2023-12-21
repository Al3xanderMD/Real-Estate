using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.HotelPensions.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllHotelPensionsQueryTests : IDisposable
    {
        private readonly IHotelPensionRepository mockHotelPensionRepository;

        public GetAllHotelPensionsQueryTests()
        {
            mockHotelPensionRepository = RepositoryMocks.GetHotelPensionRepository();
        }

        [Fact]
        public async Task GetAllHotelPensionsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllHotelPensionsQueryHandler(mockHotelPensionRepository);

            // Act
            var result = await handler.Handle(new GetAllHotelPensionsQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.HotelPensions.Should().NotBeNull();
            result.HotelPensions.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockHotelPensionRepository.ClearReceivedCalls();
        }
    }
}
