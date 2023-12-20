using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Houses.Queries.GetAll
{
    public class GetAllHousesQueryHandler : IRequestHandler<GetAllHousesQuery, GetAllHousesResponse>
    {
        private readonly IHouseRepository repository;

        public GetAllHousesQueryHandler(IHouseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllHousesResponse> Handle(GetAllHousesQuery request, CancellationToken cancellationToken)
        {
            GetAllHousesResponse response = new();
            var result = await repository.GetAllAsync();

            if(result.IsSuccess)
            {
                response.Houses = result.Value.Select(house => new HouseDto
                {
                    BasePostId = house.BasePostId,
                    UserId = house.UserId,
                    TitlePost = house.TitlePost,
                    Price = house.Price,
                    AddressId = house.AddressId,
                    OfferType = house.OfferType,
                    Description = house.Description,
                    RoomCount = house.RoomCount,
                    FloorCount = house.FloorCount,
                    UsefulSurface = house.UsefulSurface,
                    LotArea = house.LotArea,
                    BuildYear = house.BuildYear,
                    HouseTypeId = house.HouseTypeId
                }).ToList();
            }
            return response;
        }
    }
}
