using MediatR;
using RealEstate.Application.Features.LotClassifications.Queries;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.CommercialSpecifics.Queries.GetAll
{
    public class GetAllCommercialSpecificsQueryHandler : IRequestHandler<GetAllCommercialSpecificsQuery, GetAllCommercialSpecificsResponse>
    {
        private readonly ICommercialSpecificRepository repository;

        public GetAllCommercialSpecificsQueryHandler(ICommercialSpecificRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllCommercialSpecificsResponse> Handle(GetAllCommercialSpecificsQuery request, CancellationToken cancellationToken)
        {
            GetAllCommercialSpecificsResponse response = new();
            var result = await repository.GetAllAsync();

            if (result.IsSuccess)
            {
                response.CommercialSpecifics = result.Value.Select(commercialSpecific => new CommercialSpecificDto
                {
                    CommercialSpecificId = commercialSpecific.CommercialSpecificId,
                    SpecificName = commercialSpecific.SpecificName,
                    CommercialCategoryId = commercialSpecific.CommercialCategoryId
                }).ToList();
            }
            return response;
        }
    }
}
