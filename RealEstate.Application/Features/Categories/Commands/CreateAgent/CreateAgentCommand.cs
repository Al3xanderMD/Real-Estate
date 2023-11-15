using MediatR;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Categories.Commands.CreateAgent
{
    public class CreateAddressCommand : IRequest<CreateAgentCommandResponse>
    {
        public string AgentName { get; set; } = default!;
        public string Logolink { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public Address AddressId { get; set; } = default!;
        public string Url { get; set; } = default!;
        public RegAuth RegAuth { get; set; } = default!;
    }
}
