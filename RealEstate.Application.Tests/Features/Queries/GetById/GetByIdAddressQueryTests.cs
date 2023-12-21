using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Addresses.Queries;
using RealEstate.Application.Features.Addresses.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdAddressQueryTests : IDisposable
    {
        private readonly IAddressRepository mockAddressRepository;

        public GetByIdAddressQueryTests()
        {
            mockAddressRepository = RepositoryMocks.GetAddressRepository();
        }

        [Fact]
        public async Task GetAddressByIdHandler_WithValidId_ReturnsAddress()
        {
            // Arrange
            var exceptedAddress = Address.Create("Test Url", "Test AddressName").Value;

            mockAddressRepository.FindByIdAsync(exceptedAddress.Id).Returns(Task.FromResult(Result<Address>.Success(exceptedAddress)));

            var handler = new GetByIdAddressQueryHandler(mockAddressRepository);
            // Act
            var result = await handler.Handle(new GetByIdAddressQuery(exceptedAddress.Id), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new AddressDto
            {
                Id = exceptedAddress.Id,
                Url = exceptedAddress.Url,
                AddressName = exceptedAddress.AddressName
            });
        }

        [Fact]
        public async Task GetsByIdAddresHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockAddressRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<Address>.Failure("Address not found")));

            var handler = new GetByIdAddressQueryHandler(mockAddressRepository);
            // Act
            var result = await handler.Handle(new GetByIdAddressQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new AddressDto());
        }

        public void Dispose()
        {
            mockAddressRepository.ClearReceivedCalls();
        }

    }
}
