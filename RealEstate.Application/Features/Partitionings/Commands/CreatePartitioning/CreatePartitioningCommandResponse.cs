using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Partitionings.Commands.CreatePartitioning
{
    public class CreatePartitioningCommandResponse : BaseResponse
    {
        public CreatePartitioningCommandResponse() : base()
        {
        }

        public CreatePartitioningDTO Partitioning { get; set; }
    }
}
