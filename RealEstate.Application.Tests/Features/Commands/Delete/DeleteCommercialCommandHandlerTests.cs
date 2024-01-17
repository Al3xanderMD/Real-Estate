using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Commercials.Commands.DeleteCommercial;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Common;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Delete
{
    public class DeleteCommercialCommandHandlerTests : IDisposable
    {
        private readonly ICommercialRepository mockRepository;
        private readonly DeleteCommercialHandler handler;
        private readonly Commercial mockCommercial;
        private readonly ICommercialCategoryRepository mockCommercialCategoryRepository;
        private readonly CommercialCategory mockCommercialCategory;
        private readonly ICommercialSpecificRepository mockCommercialSpecificRepository;
        private readonly CommercialSpecific mockCommercialSpecific;
        private readonly IAddressRepository mockAddressRepository;
        private readonly Address mockAddress;
        private readonly string userId = new Guid("b4c2d9f0-5f6a-4f3a-8f8a-5d4e6a5b7b1e").ToString();
        private readonly DateTime date = DateTime.Now.AddYears(2);

        public DeleteCommercialCommandHandlerTests()
        {
            mockCommercialCategory = CommercialCategory.Create("Test CommercialCategory Name").Value;
            mockCommercialCategoryRepository = RepositoryMocks.GetCommercialCategoryRepository();
            mockCommercialSpecific = CommercialSpecific.Create("Test CommercialSpecific Name", mockCommercialCategory.Id).Value;
            mockCommercialSpecificRepository = RepositoryMocks.GetCommercialSpecificRepository();
            mockAddress = Address.Create("Test AddressUrl", "Test AddressName").Value;
            mockAddressRepository = RepositoryMocks.GetAddressRepository();
            mockCommercial = Commercial.Create(userId, "Test Title Post", 1, mockAddress.Id, true, "Test Description", mockCommercialSpecific.CommercialSpecificId, 1, date).Value;
            
            mockRepository = RepositoryMocks.GetCommercialRepository();
            handler = new DeleteCommercialHandler(mockRepository);
        }

        [Fact]
        public async Task DeleteCommercialCommandHandler_ValidCommand_ReturnsSuccessResponse()
        {
            // Arrange
            mockRepository.DeleteAsync(mockCommercial.BasePostId).Returns(Result<Commercial>.Success(mockCommercial));

            // Act
            var result = await handler.Handle(new DeleteCommercial { BasePostId = mockCommercial.BasePostId }, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
        }

        [Fact]
        public async Task DeleteCommercialCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            mockRepository.DeleteAsync(mockCommercial.BasePostId).Returns(Result<Commercial>.Failure("Commercial not found"));

            // Act
            var result = await handler.Handle(new DeleteCommercial { BasePostId = mockCommercial.BasePostId}, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
            mockAddressRepository.ClearReceivedCalls();
            mockCommercialSpecificRepository.ClearReceivedCalls();
            mockCommercialCategoryRepository.ClearReceivedCalls();
        }
    }
}
