using MediatR;
using RealEstate.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Features.HouseTypes.Queries.GetAll
{
    public class GetAllHouseTypesQueryHandler : IRequestHandler<GetAllHouseTypesQuery, GetAllHouseTypesResponse>
    {
        private readonly IHouseTypeRepository repository;
        public GetAllHouseTypesQueryHandler(IHouseTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<GetAllHouseTypesResponse> Handle(GetAllHouseTypesQuery request, CancellationToken cancellationToken)
        {
            GetAllHouseTypesResponse response = new();
            var result = await repository.GetAllAsync();

            if(result.IsSuccess)
            {
                response.HouseTypes = result.Value.Select(houseType => new HouseTypeDto
                {
                    Id = houseType.Id,
                    Type = houseType.Type
                }).ToList();
            }
            return response;
        }

    }
}
