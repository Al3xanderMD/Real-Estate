using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdateAddressCommandResponse>
    {
        private readonly IAddressRepository repository;

        public UpdateAddressCommandHandler(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await repository.FindByIdAsync(request.Id);
            var validator = new UpdateAddressCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new UpdateAddressCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            if (!address.IsSuccess)
            {
                return new UpdateAddressCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { address.Error }
                };
            }

            address.Value.AttachAddressName(request.AddressName);
            address.Value.AttachUrl(request.Url);
            var updatedAddress = await repository.UpdateAsync(address.Value);

            if(!updatedAddress.IsSuccess)
            {
                return new UpdateAddressCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { updatedAddress.Error }
                };
            }

            return new UpdateAddressCommandResponse
            {
                Success = true,
                Address = new UpdateAddressDto
                {
                    Url = updatedAddress.Value.Url,
                    AddressName = updatedAddress.Value.AddressName
                }
            };  
        }
    }
}
