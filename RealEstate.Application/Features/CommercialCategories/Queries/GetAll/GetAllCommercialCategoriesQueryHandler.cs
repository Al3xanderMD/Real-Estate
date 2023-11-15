using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.CommercialCategories.Queries.GetAll
{
    public class GetAllCommercialCategoriesQueryHandler : IRequestHandler<GetAllCommercialCategoriesQuery, GetAllCommercialCategoriesResponse>
    {
        private readonly ICommercialCategoryRepository repository;

        public GetAllCommercialCategoriesQueryHandler(ICommercialCategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllCommercialCategoriesResponse> Handle(GetAllCommercialCategoriesQuery request, CancellationToken cancellationToken)
        {
            GetAllCommercialCategoriesResponse response = new();
            var result = await repository.GetAllAsync();

            if (result.IsSuccess)
            {
                response.CommercialCategories = result.Value.Select(commercialCategory => new CommercialCategoryDto
                {
                    Id = commercialCategory.Id,
                    CategoryName = commercialCategory.CategoryName
                }).ToList();
            }
            return response;
        }
    }
}
