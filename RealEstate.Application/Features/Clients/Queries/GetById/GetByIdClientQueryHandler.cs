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
            var client = await repository.FindByIdAsync(request.UserId);

            if(client.IsSuccess)
            {
                return new ClientDto
                {
                    UserId = client.Value.UserId,
                    Username = client.Value.Username,
                    Email = client.Value.Email,
                    Name = client.Value.Name,
                    PhoneNumber = client.Value.PhoneNumber,
                    ImageUrl = client.Value.ImageUrl
                };
            }
            return new ClientDto();
        }
    }
}
