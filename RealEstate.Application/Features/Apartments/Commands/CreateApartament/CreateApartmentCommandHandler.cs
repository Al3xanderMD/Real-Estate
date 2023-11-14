using MediatR;
using RealEstate.Application.Features.Categories.Commands.CreateApartament;
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

            var apartment = Apartment.Create(request.RoomCount, request.Comfort, request.Floor, request.UsefulSurface, request.BuildYear, request.BasePostId, request.PartitioningId);

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
                    Id = apartment.Value.Id,
                    RoomCount = apartment.Value.RoomCount,
                    Comfort = apartment.Value.Comfort,
                    Floor = apartment.Value.Floor,
                    UsefulSurface = apartment.Value.UsefulSurface,
                    BuildYear = apartment.Value.BuildYear,
                    BasePostId = apartment.Value.BasePostId,
                    PartitioningId = apartment.Value.PartitioningId
                }
            };
        }
    }
}