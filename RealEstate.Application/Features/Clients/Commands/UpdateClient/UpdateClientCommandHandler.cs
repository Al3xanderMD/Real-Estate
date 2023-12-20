using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, UpdateClientCommandResponse>
    {
        private readonly IClientRepository repository;

        public UpdateClientCommandHandler(IClientRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateClientCommandResponse> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await repository.FindByIdAsync(request.UserId);
            var validator = new UpdateClientCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validatorResult.IsValid)
            {
                return new UpdateClientCommandResponse()
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            if (!client.IsSuccess)
            {
                return new UpdateClientCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { client.Error }
                };
            }

            client.Value.AttachName(request.Name);
            client.Value.AttachPhoneNumber(request.PhoneNumber);
            client.Value.AttachImageUrl(request.ImageUrl);

            var updatedClient = await repository.UpdateAsync(client.Value);

            if(!updatedClient.IsSuccess)
            {
                return new UpdateClientCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { updatedClient.Error }
                };
            }

            return new UpdateClientCommandResponse
            {
                Success = true,
                Client = new UpdateClientDto
                {
                    Name = updatedClient.Value.Name,
                    PhoneNumber = updatedClient.Value.PhoneNumber,
                    ImageUrl = updatedClient.Value.ImageUrl
                }
            };
        }
    }
}
