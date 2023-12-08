using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.CommercialCategories.Commands.UpdateCommercialCategory
{
	public class UpdateCommercialCategoryCommandHandler: IRequestHandler<UpdateCommercialCategoryCommand, UpdateCommercialCategoryCommandResponse>
	{
		private readonly ICommercialCategoryRepository repository;
		public UpdateCommercialCategoryCommandHandler(ICommercialCategoryRepository repository)
		{
			this.repository = repository;
		}
		public async Task<UpdateCommercialCategoryCommandResponse> Handle(UpdateCommercialCategoryCommand request, CancellationToken cancellationToken)
		{
			var commercialCategory = await repository.FindByIdAsync(request.Id);
			var validator = new UpdateCommercialCategoryCommandValidator();
			var validatorResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new UpdateCommercialCategoryCommandResponse
				{
					Success = false,
					ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!commercialCategory.IsSuccess)
			{
				return new UpdateCommercialCategoryCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { commercialCategory.Error }
				};
			}

			commercialCategory.Value.AttachCategoryName(request.CategoryName);
			var updatedCommercialCategory = await repository.UpdateAsync(commercialCategory.Value);

			if (!updatedCommercialCategory.IsSuccess)
			{
				return new UpdateCommercialCategoryCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedCommercialCategory.Error }
				};
			}

			return new UpdateCommercialCategoryCommandResponse
			{
				Success = true,
				CommercialCategory = new UpdateCommercialCategoryDto
				{
					CategoryName = updatedCommercialCategory.Value.CategoryName
				}
			};
		}
	}
}
