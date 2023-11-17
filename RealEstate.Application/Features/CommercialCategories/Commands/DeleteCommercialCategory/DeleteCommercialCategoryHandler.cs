using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.CommercialCategories.Commands.DeleteCommercialCategory
{
    public class DeleteCommercialCategoryHandler : IRequestHandler<DeleteCommercialCategory, DeleteCommercialCategoryResponse>
    {
        private readonly ICommercialCategoryRepository repository;

        public DeleteCommercialCategoryHandler(ICommercialCategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteCommercialCategoryResponse> Handle(DeleteCommercialCategory request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new DeleteCommercialCategoryResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteCommercialCategoryResponse
            {
                Success = true
            };
        }
    }
}
