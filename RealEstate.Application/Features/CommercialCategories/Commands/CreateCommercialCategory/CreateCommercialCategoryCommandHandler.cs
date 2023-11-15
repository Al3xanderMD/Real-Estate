using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;
using System.Net;

namespace RealEstate.Application.Features.CommercialCategories.Commands.CreateCommercialCategory
{
    public class CreateCommercialCategoryCommandHandler : IRequestHandler<CreateCommercialCategoryCommand, CreateCommercialCategoryCommandResponse>
    {
        private readonly ICommercialCategoryRepository repository;

        public CreateCommercialCategoryCommandHandler(ICommercialCategoryRepository repository) 
        {
            this.repository = repository;
        }
        public async Task<CreateCommercialCategoryCommandResponse> Handle(CreateCommercialCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCommercialCategoryCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.IsValid) 
            {
                return new CreateCommercialCategoryCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var commercialCategory = CommercialCategory.Create(request.CategoryName);
            if (!commercialCategory.IsSuccess) 
            {
                return new CreateCommercialCategoryCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { commercialCategory.Error }
                };
            }

            await repository.AddAsync(commercialCategory.Value);

            return new CreateCommercialCategoryCommandResponse
            {
                Success = true,
                CommercialCategory = new CreateCommercialCategoryDto
                {
                    CategoryName = commercialCategory.Value.CategoryName
                }
            };
        }
    }
}
