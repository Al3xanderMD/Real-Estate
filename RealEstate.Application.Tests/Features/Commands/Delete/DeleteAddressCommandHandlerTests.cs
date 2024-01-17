using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Addresses.Commands.DeleteAddres;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteAddressCommandHandlerTests : IDisposable
    {
        private readonly IAddressRepository mockRepository;
        private readonly DeleteAddressCommandHandler handler;
        private readonly Address mockAddress;

        public DeleteAddressCommandHandlerTests()
        {
            mockAddress = Address.Create("Test AddressUrl", "Test AddressName").Value;
            mockRepository = RepositoryMocks.GetAddressRepository();
            handler = new DeleteAddressCommandHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteAddressCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockAddress.Id).Returns(Result<Address>.Success(mockAddress));

            // Act
            var result = await handler.Handle(new DeleteAddressCommand { Id = mockAddress.Id}, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteAddressCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockAddress.Id).Returns(Result<Address>.Failure("Address not found"));

            // Act
            var result = await handler.Handle(new DeleteAddressCommand { Id = mockAddress.Id}, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
