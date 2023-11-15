using MediatR;
using RealEstate.Application.Persistence;
namespace RealEstate.Application.Features.Partitionings.Queries.GetById
{
    public class GetByIdPartitioningQueryHandler : IRequestHandler<GetByIdPartitioningQuery, PartitioningsDto>
    {
        private readonly IPartitioningRepository repository;
        public GetByIdPartitioningQueryHandler(IPartitioningRepository repository)
        {
            this.repository = repository;
        }
        public async Task<PartitioningsDto> Handle(GetByIdPartitioningQuery request, CancellationToken cancellationToken)
        {
            var partitioning = await repository.FindByIdAsync(request.Id);
            if(partitioning.IsSuccess)
            {
                return new PartitioningsDto
                {
                    Id = partitioning.Value.Id,
                    Type = partitioning.Value.Type
                };
            }
            return new PartitioningsDto();
        }
    }
}
