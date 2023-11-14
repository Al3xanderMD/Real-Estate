using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Apartments.Commands.CreatePartitioning
{
    public class CreatePartitioningCommandResponse : BaseResponse
    {
        public CreatePartitioningCommandResponse() : base()
        {
        }

        public CreatePartitioningDTO Partitioning { get; set; }
    }
}
