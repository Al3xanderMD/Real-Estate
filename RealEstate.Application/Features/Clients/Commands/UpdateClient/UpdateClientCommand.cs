using MediatR;

namespace RealEstate.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<UpdateClientCommandResponse>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}
