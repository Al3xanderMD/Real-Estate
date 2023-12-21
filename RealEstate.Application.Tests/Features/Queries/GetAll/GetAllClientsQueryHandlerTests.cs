using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Clients.Queries.GetAll;
using RealEstate.Application.Persistence;


namespace RealEstate.Application.Tests.Features.Queries.GetAll
{
    public class GetAllClientsQueryHandlerTests : IDisposable
    {
        private readonly IClientRepository mockClientRepository;

        public GetAllClientsQueryHandlerTests()
        {
            mockClientRepository = RepositoryMocks.GetClientRepository();
        }

        [Fact]
        public async Task GetAllClientsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetAllClientsQueryHandler(mockClientRepository);

            // Act
            var result = await handler.Handle(new GetAllClientsQuery(), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Clients.Should().NotBeNull();
            result.Clients.Should().HaveCount(2);
            
        }

        public void Dispose()
        {
            mockClientRepository.ClearReceivedCalls();
        }
    }
}
