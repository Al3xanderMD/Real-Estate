using MediatR;

namespace RealEstate.Application.Features.Partitionings.Commands.UpdatePartitioning
{
	public class UpdatePartitioningCommand: IRequest<UpdatePartitioningCommandResponse>
	{
		public Guid Id { get; set; }
		public string Type { get; set; } = default!;

	}
}
