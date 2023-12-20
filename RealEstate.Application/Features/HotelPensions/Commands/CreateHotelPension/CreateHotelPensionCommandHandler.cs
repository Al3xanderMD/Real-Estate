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

            var hotelPension = HotelPension.Create(request.UserId, request.TitlePost, request.Price, request.AddressId, request.OfferType,request.Description, request.UsefulSurface,request.RoomSurface,request.RoomCount);
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
                    BasePostId = hotelPension.Value.BasePostId,
                    UserId = hotelPension.Value.UserId,
                    TitlePost = hotelPension.Value.TitlePost,
                    Price = hotelPension.Value.Price,
                    AddressId = hotelPension.Value.AddressId,
                    OfferType = hotelPension.Value.OfferType,
                    Description = hotelPension.Value.Description,
                    UsefulSurface = hotelPension.Value.UsefulSurface,
                    RoomSurface = hotelPension.Value.RoomSurface,
                    RoomCount = hotelPension.Value.RoomCount
                }
            };
        }
    }
}
