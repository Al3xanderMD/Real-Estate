using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Clients.Queries.GetAll
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, GetAllClientsResponse>
    {
        private readonly IClientRepository repository;

        public GetAllClientsQueryHandler(IClientRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllClientsResponse> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            GetAllClientsResponse response = new();
            var result = await repository.GetAllAsync();

            if(result.IsSuccess)
            {
                response.Clients = result.Value.Select(client => new ClientDto
                {
                    UserId = client.UserId,
                    Username = client.Username,
                    Email = client.Email,
                    Name = client.Name,
                    PhoneNumber = client.PhoneNumber,
                    ImageUrl = client.ImageUrl
                }).ToList();
            }
            return response;
        }
    }
}
