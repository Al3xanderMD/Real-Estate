using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Lots.Commands.CreateLot
{
    public class CreateLotCommandHandler : IRequestHandler<CreateLotCommand, CreateLotCommandResponse>
    {
        private readonly ILotRepository repository;

        public CreateLotCommandHandler(ILotRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateLotCommandResponse> Handle(CreateLotCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLotCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreateLotCommandResponse
                {
                    Success = false,
                    ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var lot = Lot.Create(request.UserId, request.TitlePost, request.Price, request.AddressId, request.OfferType, request.Description,
                request.LotArea, request.StreetFrontage, request.LotClassificationId);

            if (!lot.IsSuccess)
            {
                return new CreateLotCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { lot.Error }
                };
            }

            await repository.AddAsync(lot.Value);

            return new CreateLotCommandResponse
            {
                Success = true,
                Lot = new CreateLotDTO
                {
                    BasePostId = lot.Value.BasePostId,
                    UserId = lot.Value.UserId,
                    TitlePost = lot.Value.TitlePost,
                    Price = lot.Value.Price,
                    AddressId = lot.Value.AddressId,
                    OfferType = lot.Value.OfferType,
                    Description = lot.Value.Description,
                    LotArea = lot.Value.LotArea,
                    StreetFrontage = lot.Value.StreetFrontage,
                    LotClassificationId = lot.Value.LotClassificationId
                }
            };
        }
    }


}
