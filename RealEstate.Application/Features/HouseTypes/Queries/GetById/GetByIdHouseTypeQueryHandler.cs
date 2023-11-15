using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.HouseTypes.Queries.GetById
{
    public class GetByIdHouseTypeQueryHandler : IRequestHandler<GetByIdHouseTypeQuery, HouseTypeDto>
    {
        private readonly IHouseTypeRepository repository;
        public GetByIdHouseTypeQueryHandler(IHouseTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<HouseTypeDto> Handle(GetByIdHouseTypeQuery request, CancellationToken cancellationToken)
        {
            var houseType = await repository.FindByIdAsync(request.Id);
            if(houseType.IsSuccess)
            {
                return new HouseTypeDto
                {
                    Id = houseType.Value.Id,
                    Type = houseType.Value.Type
                };
            }
            return new HouseTypeDto();
        }
    }
}
