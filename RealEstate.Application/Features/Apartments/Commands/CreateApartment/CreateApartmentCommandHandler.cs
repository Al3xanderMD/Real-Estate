using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Apartments.Commands.CreateApartament
{
    public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand, CreateApartmentCommandResponse>
    {
        private readonly IApartmentRepository repository;

        public CreateApartmentCommandHandler(IApartmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateApartmentCommandResponse> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateApartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreateApartmentCommandResponse
                {
                    Success = false,
                    ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var apartment = Apartment.Create(request.UserId, request.TitlePost, request.Price,request.AddressId, request.OfferType, request.Description,
                request.RoomCount, request.Comfort, request.Floor, request.UsefulSurface, request.BuildYear, request.PartitioningId);

            if (!apartment.IsSuccess)
            {
                return new CreateApartmentCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { apartment.Error }
                };
            }

            await repository.AddAsync(apartment.Value);

            return new CreateApartmentCommandResponse
            {
                Success = true,
                Apartment = new CreateApartmentDTO
                {
                    BasePostId = apartment.Value.BasePostId,
                    UserId = apartment.Value.UserId,
                    TitlePost = apartment.Value.TitlePost,
                    Price = apartment.Value.Price,
                    AddressId = apartment.Value.AddressId,
                    OfferType = apartment.Value.OfferType,
                    Description = apartment.Value.Description,
                    RoomCount = apartment.Value.RoomCount,
                    Comfort = apartment.Value.Comfort,
                    Floor = apartment.Value.Floor,
                    UsefulSurface = apartment.Value.UsefulSurface,
                    BuildYear = apartment.Value.BuildYear,
                    PartitioningId = apartment.Value.PartitioningId
                }
            };
        }
    }
}