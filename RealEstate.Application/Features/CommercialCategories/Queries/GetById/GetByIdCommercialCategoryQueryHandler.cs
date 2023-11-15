using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.CommercialCategories.Queries.GetById
{
    public class GetByIdCommercialCategoryQueryHandler : IRequestHandler<GetByIdCommercialCategoryQuery, CommercialCategoryDto>
    {
        private readonly ICommercialCategoryRepository repository;

        public GetByIdCommercialCategoryQueryHandler(ICommercialCategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CommercialCategoryDto> Handle(GetByIdCommercialCategoryQuery request, CancellationToken cancellationToken)
        {
            var commercialCategory = await repository.FindByIdAsync(request.Id);

            if (commercialCategory.IsSuccess)
            {
                return new CommercialCategoryDto
                {
                    Id = commercialCategory.Value.Id,
                    CategoryName = commercialCategory.Value.CategoryName
                };
            }
            return new CommercialCategoryDto();
        }
    }
}
