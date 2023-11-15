using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.HouseTypes.Commands.CreateHouseType
{
    public class CreateHouseTypeCommandHandler : IRequestHandler<CreateHouseTypeCommand, CreateHouseTypeCommandResponse>
    {
        private readonly IHouseTypeRepository repository;
        public CreateHouseTypeCommandHandler(IHouseTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<CreateHouseTypeCommandResponse> Handle(CreateHouseTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateHouseTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreateHouseTypeCommandResponse
                {
                    Success = false,
                    ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var houseType = HouseType.Create(request.Type);

            if (!houseType.IsSuccess)
            {
                return new CreateHouseTypeCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { houseType.Error }
                };
            }

            await repository.AddAsync(houseType.Value);

            return new CreateHouseTypeCommandResponse
            {
                Success = true,
                HouseType = new CreateHouseTypeDTO
                {
                    Id = houseType.Value.Id,
                    Type = houseType.Value.Type
                }
            };
        }
    }
}
