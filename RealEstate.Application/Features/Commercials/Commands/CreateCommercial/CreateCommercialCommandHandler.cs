using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Commercials.Commands.CreateCommercial
{
	public class CreateCommercialCommandHandler : IRequestHandler<CreateCommercialCommand, CreateCommercialCommandResponse>
    {
        private readonly ICommercialRepository repository;
        public CreateCommercialCommandHandler(ICommercialRepository repository) 
        {
            this.repository = repository;
        }
        public async Task<CreateCommercialCommandResponse> Handle(CreateCommercialCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCommercialCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid) 
            {
                return new CreateCommercialCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var commercial = Commercial.Create(request.UserId, request.TitlePost, request.Price, request.AddressId, request.OfferType, request.Description,
                request.CommercialSpecificId, request.UsefulSurface, request.Disponibility);

            if (!commercial.IsSuccess) 
            {
                return new CreateCommercialCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { commercial.Error }
                };
            }

            await repository.AddAsync(commercial.Value);

            return new CreateCommercialCommandResponse 
            {
                Success = true,
                Commercial = new CreateCommercialDto 
                {
                    BasePostId = commercial.Value.BasePostId,
                    UserId = commercial.Value.UserId,
                    TitlePost = commercial.Value.TitlePost,
                    Price = commercial.Value.Price,
                    AddressId = commercial.Value.AddressId,
                    OfferType = commercial.Value.OfferType,
                    Description = commercial.Value.Description,
                    CommercialSpecificId = commercial.Value.CommercialSpecificId,
                    UsefulSurface = commercial.Value.UsefulSurface,
                    Disponibility = commercial.Value.Disponibility
                }
            };
        }
    }
}
