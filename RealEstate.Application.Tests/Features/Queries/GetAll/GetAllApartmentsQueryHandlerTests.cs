using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Apartments.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllApartmentsQueryHandlerTests : IDisposable
    {
        private readonly IApartmentRepository mockApartmentRepository;

        public GetAllApartmentsQueryHandlerTests()
        {
            mockApartmentRepository = RepositoryMocks.GetApartmentRepository();
        }

        [Fact]
        public async Task GetAllApartmentsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllApartmentsQueryHandler(mockApartmentRepository);

            // Act
            var result = await handler.Handle(new GetAllApartmentsQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Apartments.Should().NotBeNull();
            result.Apartments.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockApartmentRepository.ClearReceivedCalls();
        }
    }
}
