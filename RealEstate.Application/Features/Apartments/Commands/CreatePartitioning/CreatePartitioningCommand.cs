using MediatR;

namespace RealEstate.Application.Features.Apartments.Commands.CreatePartitioning
{
    public class CreatePartitioningCommand : IRequest<CreatePartitioningCommandResponse>
    {
        public string Type { get; set; } = default!;
    }
}
