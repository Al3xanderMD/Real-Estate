using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Partitionings.Queries.GetAll
{
    public class GetAllPartitioningsQueryHandler : IRequestHandler<GetAllPartitioningsQuery, GetAllPartitioningsResponse>
    {
        private readonly IPartitioningRepository repository;
        public GetAllPartitioningsQueryHandler(IPartitioningRepository repository)
        {
            this.repository = repository;
        }
        public async Task<GetAllPartitioningsResponse> Handle(GetAllPartitioningsQuery request, CancellationToken cancellationToken)
        {
            GetAllPartitioningsResponse response = new();
            var result = await repository.GetAllAsync();
            if(result.IsSuccess)
            {
                response.Partitionings = result.Value.Select(partitioning => new PartitioningsDto
                {
                    Id = partitioning.Id,
                    Type = partitioning.Type
                }).ToList();
            }
            return response;
        }
    }
}
