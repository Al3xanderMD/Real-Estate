using MediatR;

namespace RealEstate.Application.Features.Partitionings.Commands.CreatePartitioning
{
    public class CreatePartitioningCommand : IRequest<CreatePartitioningCommandResponse>
    {
        public string Type { get; set; } = default!;
    }
}
