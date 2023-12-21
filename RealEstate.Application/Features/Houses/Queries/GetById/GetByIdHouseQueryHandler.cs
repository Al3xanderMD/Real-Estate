using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Houses.Queries.GetById
{
    public class GetByIdHouseQueryHandler : IRequestHandler<GetByIdHouseQuery, HouseDto>
    {
        private readonly IHouseRepository repository;

        public GetByIdHouseQueryHandler(IHouseRepository repository)
        {
            this.repository = repository;
        }
        public async Task<HouseDto> Handle(GetByIdHouseQuery request, CancellationToken cancellationToken)
        {
            var house = await repository.FindByIdAsync(request.Id);

            if(house.IsSuccess)
            {
                return new HouseDto
                {
                    BasePostId = house.Value.BasePostId,
                    UserId = house.Value.UserId,
                    TitlePost = house.Value.TitlePost,
                    Price = house.Value.Price,
                    AddressId = house.Value.AddressId,
                    OfferType = house.Value.OfferType,
                    Description = house.Value.Description,
                    RoomCount = house.Value.RoomCount,
                    FloorCount = house.Value.FloorCount,
                    UsefulSurface = house.Value.UsefulSurface,
                    LotArea = house.Value.LotArea,
                    BuildYear = house.Value.BuildYear,
                    HouseTypeId = house.Value.HouseTypeId
                };
            }
            return new HouseDto();
        }
    }
}
