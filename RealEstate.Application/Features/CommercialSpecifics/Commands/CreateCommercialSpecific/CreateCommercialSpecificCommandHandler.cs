using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;
using System.Net;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.CreateCommercialSpecific
{
    public class CreateCommercialSpecificCommandHandler : IRequestHandler<CreateCommercialSpecificCommand, CreateCommercialSpecificCommandResponse>
    {
        private readonly ICommercialSpecificRepository repository;

        public CreateCommercialSpecificCommandHandler(ICommercialSpecificRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateCommercialSpecificCommandResponse> Handle(CreateCommercialSpecificCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCommercialSpecificCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid) 
            {
                return new CreateCommercialSpecificCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var commercialSpecific = CommercialSpecific.Create(request.SpecificName,request.CommercialCategoryId);
            if(!commercialSpecific.IsSuccess)
            {
                return new CreateCommercialSpecificCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { commercialSpecific.Error }
                };
            }

            await repository.AddAsync(commercialSpecific.Value);

            return new CreateCommercialSpecificCommandResponse
            {
                Success = true,
                CommercialSpecific = new CreateCommercialSpecificDto
                {
                    CommercialSpecificId = commercialSpecific.Value.CommercialSpecificId,
                    SpecificName = commercialSpecific.Value.SpecificName,
                    CommercialCategoryId = commercialSpecific.Value.CommercialCategoryId

                }
            };
        }
    }
}
