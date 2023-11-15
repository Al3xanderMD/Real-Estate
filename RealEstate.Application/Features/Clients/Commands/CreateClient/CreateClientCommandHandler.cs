using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Categories.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientCommandResponse>
    {
        private readonly IClientRepository repository;

        public CreateClientCommandHandler(IClientRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateClientCommandResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateClientCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validatorResult.IsValid)
            {
                return new CreateClientCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var client = Client.Create(request.FirstName, request.LastName);
            if(!client.IsSuccess)
            {
                return new CreateClientCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { client.Error }
                };
            }

            await repository.AddAsync(client.Value);

            return new CreateClientCommandResponse
            {
                Success = true,
                Client = new CreateClientDto
                {
                    ClientId = client.Value.ClientId,
                    FirstName = client.Value.FirstName,
                    LastName = client.Value.LastName
                }
            };

        }
    }
}
