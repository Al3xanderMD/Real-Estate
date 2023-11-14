using MediatR;

namespace RealEstate.Application.Features.Categories.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<CreateClientCommandResponse>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
