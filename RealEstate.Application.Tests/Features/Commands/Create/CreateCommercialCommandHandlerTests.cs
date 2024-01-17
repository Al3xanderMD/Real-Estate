using FluentAssertions;
using NSubstitute;
using RealEstate.Application.Features.Commercials.Commands.CreateCommercial;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Tests.Features.Commands.Create
{
    public class CreateCommercialCommandHandlerTests : IDisposable
    {
        private readonly ICommercialRepository mockRepository;

        public CreateCommercialCommandHandlerTests()
        {
            mockRepository = RepositoryMocks.GetCommercialRepository();
        }

        [Fact]
        public async Task CreateCommercialCommandHandler_ValidCommand_ReturnsSuccesResponse()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "Test Title";
            var price = 1;
            var offerType = true;
            var description = "Test Description";
            var usefulSurface = 1;
            DateTime disponibility = DateTime.Now.AddYears(2);
            var commercialCategory = CommercialCategory.Create("Test CommercialCategory").Value;
            var commercialSpecific = CommercialSpecific.Create("Test CommercialSpecific", commercialCategory.Id).Value;

            var commercial = Commercial.Create(userId, titlePost, price, address.Id, offerType, description,
                               commercialSpecific.CommercialSpecificId, usefulSurface, disponibility);


            var command = new CreateCommercialCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description,
                CommercialSpecificId = commercialSpecific.CommercialSpecificId,
                UsefulSurface = usefulSurface,
                Disponibility = disponibility
            };

            var handler = new CreateCommercialCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.ValidationErrors.Should().BeNull();
            result.Commercial.Should().NotBeNull();
            result.Commercial.UserId.Should().Be(commercial.Value.UserId);
            result.Commercial.TitlePost.Should().Be(commercial.Value.TitlePost);
            result.Commercial.Price.Should().Be(commercial.Value.Price);
            result.Commercial.AddressId.Should().Be(commercial.Value.AddressId);
            result.Commercial.OfferType.Should().Be(commercial.Value.OfferType);
            result.Commercial.Description.Should().Be(commercial.Value.Description);
            result.Commercial.CommercialSpecificId.Should().Be(commercial.Value.CommercialSpecificId);
            result.Commercial.UsefulSurface.Should().Be(commercial.Value.UsefulSurface);
            result.Commercial.Disponibility.Should().Be(commercial.Value.Disponibility);

        }

        [Fact]
        public async Task CreateCommercialCommandHandler_InvalidCommand_ReturnsValidationErrors()
        {
            // Arrange
            var address = Address.Create("Test AddressUrl", "Test AddressName").Value;
            var userId = new Guid("b2e0a6b9-9e5f-4e9b-9b1a-3b3b2c4d5e6f").ToString();
            var titlePost = "";
            var price = 1;
            var offerType = true;
            var description = "Test Description";
            var usefulSurface = 1;
            DateTime disponibility = DateTime.Now.AddYears(2);
            var commercialCategory = CommercialCategory.Create("Test CommercialCategory").Value;
            var commercialSpecific = CommercialSpecific.Create("Test CommercialSpecific", commercialCategory.Id).Value;

            var commercial = Commercial.Create(userId, titlePost, price, address.Id, offerType, description,
                                              commercialSpecific.CommercialSpecificId, usefulSurface, disponibility);

            var command = new CreateCommercialCommand
            {
                UserId = userId,
                TitlePost = titlePost,
                Price = price,
                AddressId = address.Id,
                OfferType = offerType,
                Description = description,
                CommercialSpecificId = commercialSpecific.CommercialSpecificId,
                UsefulSurface = usefulSurface,
                Disponibility = disponibility
            };

            var handler = new CreateCommercialCommandHandler(mockRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.ValidationErrors.Should().NotBeNull().And.NotBeEmpty();
            result.Commercial.Should().BeNull();
        }

        public void Dispose()
        {
            mockRepository.ClearReceivedCalls();
        }
    }
}
