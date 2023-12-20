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
                    BasePostId = apartment.Value.BasePostId,
                    UserId = apartment.Value.UserId,
                    TitlePost = apartment.Value.TitlePost,
                    Price = apartment.Value.Price,
                    AddressId = apartment.Value.AddressId,
                    OfferType = apartment.Value.OfferType,
                    Description = apartment.Value.Description,
                    RoomCount = apartment.Value.RoomCount,
                    Comfort = apartment.Value.Comfort,
                    Floor = apartment.Value.Floor,
                    UsefulSurface = apartment.Value.UsefulSurface,
                    BuildYear = apartment.Value.BuildYear,
                    PartitioningId = apartment.Value.PartitioningId
                };
            }
            return new ApartmentDto();
        }
    }
}
