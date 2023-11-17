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

            var lot = Lot.Create(request.BasePostId, request.LotArea, request.StreetFrontage, request.LotClassificationId);

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
                    Id = lot.Value.Id,
                    LotArea = lot.Value.LotArea,
                    StreetFrontage = lot.Value.StreetFrontage,
                    BasePostId = lot.Value.BasePostId,
                    LotClassificationId = lot.Value.LotClassificationId
                }
            };
        }
    }


}
