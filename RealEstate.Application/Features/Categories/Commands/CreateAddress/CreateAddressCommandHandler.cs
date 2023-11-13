using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Categories.Commands.CreateAddress
{
    public class CreateAddressCommandHandler
    : IRequestHandler<CreateAddressCommand, CreateAddressCommandResponse>
    {
        private readonly IAddressRepository repository;

        public CreateAddressCommandHandler(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAddressCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validatorResult.IsValid)
            {
                return new CreateAddressCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
                
            }

            var address = Address.Create(request.Url, request.AddressName);
            if(!address.IsSuccess)
            {
                return new CreateAddressCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { address.Error }
                };
            }

            await repository.AddAsync(address.Value);

            return new CreateAddressCommandResponse
            {
                Success = true,
                Address = new CreateAddressDto
                {
                    Id = address.Value.Id,
                    Url = address.Value.Url,
                    AddressName = address.Value.AddressName
                }
            };
        }
    }
}