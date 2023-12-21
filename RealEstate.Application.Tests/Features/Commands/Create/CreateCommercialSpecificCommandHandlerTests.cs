using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.CommercialSpecifics.Commands.CreateCommercialSpecific;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateCommercialSpecificCommandHandlerTests : IDisposable
    {
        private readonly ICommercialSpecificRepository mockRepository;

        public CreateCommercialSpecificCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetCommercialSpecificRepository();
        }

        [Fact]
        public async Task CreateCommercialSpecificCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var category = CommercialCategory.Create("Test Category").Value;
            var specificName = "Test CommercialSpecificName";

            var commercialSpecific = CommercialSpecific.Create(specificName, category.Id);

            var command = new CreateCommercialSpecificCommand
            {
                SpecificName = specificName,
                CommercialCategoryId = category.Id
            };

            var handler = new CreateCommercialSpecificCommandHandler(mockRepository);
            //var exceptedResult = Result<CommercialSpecific>.Success(commercialSpecific);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.CommercialSpecific.Should().NotBeNull();
            result.CommercialSpecific.SpecificName.Should().Be(commercialSpecific.Value.SpecificName);
            result.CommercialSpecific.CommercialCategoryId.Should().Be(commercialSpecific.Value.CommercialCategoryId);
        }

        [Fact]
        public async Task CreateCommercialSpecificCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var category = CommercialCategory.Create("Test Category").Value;
            var specificName = "";

            var commercialSpecific = CommercialSpecific.Create(specificName, category.Id);

            var command = new CreateCommercialSpecificCommand
            {
                SpecificName = specificName,
                CommercialCategoryId = category.Id
            };

            var handler = new CreateCommercialSpecificCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.CommercialSpecific.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
