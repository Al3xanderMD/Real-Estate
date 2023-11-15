using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Apartments.Queries.GetAll
{
    public class GetAllApartmentsQueryHandler : IRequestHandler<GetAllApartmentsQuery, GetAllApartmentsResponse>
    {
        private readonly IApartmentRepository repository;

        public GetAllApartmentsQueryHandler(IApartmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllApartmentsResponse> Handle(GetAllApartmentsQuery request, CancellationToken cancellationToken)
        {
            GetAllApartmentsResponse response = new();
            var result = await repository.GetAllAsync();

            if(result.IsSuccess)
            {
                response.Apartments = result.Value.Select(apartment => new ApartmentDto
                {
                    Id = apartment.Id,
                    RoomCount = apartment.RoomCount,
                    Comfort = apartment.Comfort,
                    Floor = apartment.Floor,
                    UsefulSurface = apartment.UsefulSurface,
                    BuildYear = apartment.BuildYear,
                    BasePostId = apartment.BasePostId,
                    PartitioningId = apartment.PartitioningId
                }).ToList();
            }
            return response;
        }
    }
}
