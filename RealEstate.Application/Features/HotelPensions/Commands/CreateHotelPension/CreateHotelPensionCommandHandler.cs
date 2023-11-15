using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.HotelPensions.Commands.CreateHotelPension
{
    public class CreateHotelPensionCommandHandler : IRequestHandler<CreateHotelPensionCommand, CreateHotelPensionCommandResponse>
    {
        private readonly IHotelPensionRepository repository;

        public CreateHotelPensionCommandHandler(IHotelPensionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateHotelPensionCommandResponse> Handle(CreateHotelPensionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateHotelPensionCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid) 
            {
                return new CreateHotelPensionCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var hotelPension = HotelPension.Create(request.BasePostId,request.UsefulSurface,request.RoomSurface,request.RoomCount);
            if (!hotelPension.IsSuccess)
            {
                return new CreateHotelPensionCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { hotelPension.Error }
                };
            }

            await repository.AddAsync(hotelPension.Value);

            return new CreateHotelPensionCommandResponse
            {
                Success = true,
                HotelPension = new CreateHotelPensionDto
                {
                    Id = hotelPension.Value.Id,
                    BasePostId = hotelPension.Value.BasePostId,
                    UsefulSurface = hotelPension.Value.UsefulSurface,
                    RoomSurface = hotelPension.Value.RoomSurface,
                    RoomCount = hotelPension.Value.RoomCount
                }
            };
        }
    }
}
