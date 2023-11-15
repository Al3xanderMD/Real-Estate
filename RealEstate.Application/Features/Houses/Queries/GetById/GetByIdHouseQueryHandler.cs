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
                    Id = house.Value.Id,
                    RoomCount = house.Value.RoomCount,
                    FloorCount = house.Value.FloorCount,
                    UsefulSurface = house.Value.UsefulSurface,
                    LotArea = house.Value.LotArea,
                    BuildYear = house.Value.BuildYear,
                    BasePostId = house.Value.BasePostId,
                    HouseTypeId = house.Value.HouseTypeId
                };
            }
            return new HouseDto();
        }
    }
}
