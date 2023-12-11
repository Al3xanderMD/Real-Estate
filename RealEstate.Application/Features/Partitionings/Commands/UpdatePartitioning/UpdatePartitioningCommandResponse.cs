using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Partitionings.Commands.UpdatePartitioning
{
	public class UpdatePartitioningCommandResponse: BaseResponse
	{
		public UpdatePartitioningCommandResponse(): base()
		{
			
		}

		public UpdatePartitioningDto Partitioning { get; set; }
	}
}