using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Addresses.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllAddressesQueryHandlerTests : IDisposable
    {
        private readonly IAddressRepository mockAddressRepository;

        public GetAllAddressesQueryHandlerTests()
        {
            mockAddressRepository = RepositoryMocks.GetAddressRepository();
        }

        [Fact]
        public async Task GetAllAddressesQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllAddressesQueryHandler(mockAddressRepository);

            // Act
            var result = await handler.Handle(new GetAllAddressesQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Addresses.Should().NotBeNull();
            result.Addresses.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockAddressRepository.ClearReceivedCalls();
        }
    }
}
