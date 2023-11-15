using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Apartments.Queries.GetById
{
    public class GetByIdApartmentqueryHandler : IRequestHandler<GetByIdApartmentQuery, ApartmentDto>
    {
        private readonly IApartmentRepository repository;

        public GetByIdApartmentqueryHandler(IApartmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ApartmentDto> Handle(GetByIdApartmentQuery request, CancellationToken cancellationToken)
        {
            var apartment = await repository.FindByIdAsync(request.Id);

            if(apartment.IsSuccess)
            {
                return new ApartmentDto
                {
                    Id = apartment.Value.Id,
                    RoomCount = apartment.Value.RoomCount,
                    Comfort = apartment.Value.Comfort,
                    Floor = apartment.Value.Floor,
                    UsefulSurface = apartment.Value.UsefulSurface,
                    BuildYear = apartment.Value.BuildYear,
                    BasePostId = apartment.Value.BasePostId,
                    PartitioningId = apartment.Value.PartitioningId
                };
            }
            return new ApartmentDto();
        }
    }
}
