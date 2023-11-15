using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.CommercialSpecifics.Queries.GetById
{
    public class GetByIdCommercialSpecificQueryHandler : IRequestHandler<GetByIdCommercialSpecificQuery, CommercialSpecificDto>
    {
        private readonly ICommercialSpecificRepository repository;

        public GetByIdCommercialSpecificQueryHandler(ICommercialSpecificRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CommercialSpecificDto> Handle(GetByIdCommercialSpecificQuery request, CancellationToken cancellationToken)
        {
            var commercialSpecific = await repository.FindByIdAsync(request.CommercialSpecificId);

            if (commercialSpecific.IsSuccess)
            {
                return new CommercialSpecificDto
                {
                    CommercialSpecificId = commercialSpecific.Value.CommercialSpecificId,
                    SpecificName = commercialSpecific.Value.SpecificName,
                    CommercialCategoryId = commercialSpecific.Value.CommercialCategoryId
                };
            }
            return new CommercialSpecificDto();
        }
    }
}
