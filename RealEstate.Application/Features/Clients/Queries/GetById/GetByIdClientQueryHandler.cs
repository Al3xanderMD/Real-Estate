using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Clients.Queries.GetById
{
    public class GetByIdClientQueryHandler : IRequestHandler<GetByIdClientQuery, ClientDto>
    {
        private readonly IClientRepository repository;

        public GetByIdClientQueryHandler(IClientRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ClientDto> Handle(GetByIdClientQuery request, CancellationToken cancellationToken)
        {
            var client = await repository.FindByIdAsync(request.ClientId);

            if(client.IsSuccess)
            {
                return new ClientDto
                {
                    ClientId = client.Value.ClientId,
                    FirstName = client.Value.FirstName,
                    LastName = client.Value.LastName
                };
            }
            return new ClientDto();
        }
    }
}
