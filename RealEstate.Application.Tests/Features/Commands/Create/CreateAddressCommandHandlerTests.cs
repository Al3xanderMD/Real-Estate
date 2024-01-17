using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Addresses.Commands.CreateAddress;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateAddressCommandHandlerTests : IDisposable
    {
        private readonly IAddressRepository mockRepository;

        public CreateAddressCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetAddressRepository();
        }

        [Fact]
        public async Task CreateAddressCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var addressUrl = "Test AddressUrl";
            var addressName = "Test AddressName";

            var address = Address.Create(addressUrl, addressName);

            var command = new CreateAddressCommand
            {
                Url = addressUrl,
                AddressName = addressName
            };
            
            var handler = new CreateAddressCommandHandler(mockRepository);
            //var exceptedResult = Result<Address>.Success(address);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.Address.Should().NotBeNull();
            result.Address.Url.Should().Be(address.Value.Url);
            result.Address.AddressName.Should().Be(address.Value.AddressName);
        }

        [Fact]
        public async Task CreateAddressCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var addressUrl = "";
            var addressName = "Test AddressName";

            var address = Address.Create(addressUrl, addressName);

            var command = new CreateAddressCommand
            {
                Url = addressUrl,
                AddressName = addressName
            };

            var handler = new CreateAddressCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.Address.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
