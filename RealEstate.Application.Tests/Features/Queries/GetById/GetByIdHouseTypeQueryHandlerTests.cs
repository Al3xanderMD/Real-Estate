using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.HouseTypes.Queries;
using RealEstate.Application.Features.HouseTypes.Queries.GetById;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Queries.GetById
{
    public class GetByIdHouseTypeQueryHandlerTests : IDisposable
    {
        private readonly IHouseTypeRepository mockHouseTypeRepository;

        public GetByIdHouseTypeQueryHandlerTests()
        {
            mockHouseTypeRepository = RepositoryMocks.GetHouseTypeRepository();
        }

        [Fact]
        public async Task GetByIdHouseTypeHandler_WithValidId_ReturnsHouseType()
        {
            // Arrange
            var exceptedHouseType = HouseType.Create("Test Type").Value;

            mockHouseTypeRepository.FindByIdAsync(exceptedHouseType.Id).Returns(Task.FromResult(Result<HouseType>.Success(exceptedHouseType)));

            var handler = new GetByIdHouseTypeQueryHandler(mockHouseTypeRepository);
            // Act
            var result = await handler.Handle(new GetByIdHouseTypeQuery(exceptedHouseType.Id), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new HouseTypeDto
            {
                Id = exceptedHouseType.Id,
                Type = exceptedHouseType.Type
            });
        }

        [Fact]
        public async Task GetByIdHouseTypeHandler_WithInvalidId_ReturnsFailure()
        {
            // Arrange
            var invalidId = new Guid("a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5678");

            mockHouseTypeRepository.FindByIdAsync(invalidId).Returns(Task.FromResult(Result<HouseType>.Failure("HouseType not found")));

            var handler = new GetByIdHouseTypeQueryHandler(mockHouseTypeRepository);
            // Act
            var result = await handler.Handle(new GetByIdHouseTypeQuery(invalidId), CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new HouseTypeDto());
        }

        public void Dispose()
        {
            mockHouseTypeRepository.ClearReceivedCalls();
        }
    }
}
