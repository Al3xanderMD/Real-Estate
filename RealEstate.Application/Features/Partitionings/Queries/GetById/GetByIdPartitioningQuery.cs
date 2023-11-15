using MediatR;

namespace RealEstate.Application.Features.Partitionings.Queries.GetById
{
    public record GetByIdPartitioningQuery(Guid Id) : IRequest<PartitioningsDto>;
}
