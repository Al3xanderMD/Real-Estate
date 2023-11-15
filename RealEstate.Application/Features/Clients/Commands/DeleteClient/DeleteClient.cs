using MediatR;

namespace RealEstate.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClient : IRequest<DeleteClientResponse>
    {
        public Guid ClientId { get; set; }
    }
}

