using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.UpdateCommercialSpecific
{
	public class UpdateCommercialSpecificCommandHandler: IRequestHandler<UpdateCommercialSpecificCommand,UpdateCommercialSpecificCommandResponse>
	{
		private readonly ICommercialSpecificRepository repository;
		public UpdateCommercialSpecificCommandHandler(ICommercialSpecificRepository repository)
		{
			this.repository = repository;
		}

		public async Task<UpdateCommercialSpecificCommandResponse> Handle(UpdateCommercialSpecificCommand request, CancellationToken cancellationToken)
		{
			var commercialSpecific = await repository.FindByIdAsync(request.Id);
			var validator = new UpdateCommercialSpecificCommandValidator();
			var validatorResult = await validator.ValidateAsync(request, cancellationToken);
		
			if (!validatorResult.IsValid)
			{
				return new UpdateCommercialSpecificCommandResponse
				{
					Success = false,
					ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!commercialSpecific.IsSuccess)
			{
				return new UpdateCommercialSpecificCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { commercialSpecific.Error }
				};
			}

			commercialSpecific.Value.AttachSpecificName(request.SpecificName);
			commercialSpecific.Value.AttachCommercialCategoryId(request.CommercialCategoryId);
			var updatedCommercialSpecific = await repository.UpdateAsync(commercialSpecific.Value);
		
			if (!updatedCommercialSpecific.IsSuccess)
			{
				return new UpdateCommercialSpecificCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedCommercialSpecific.Error }
				};
			}

			return new UpdateCommercialSpecificCommandResponse
			{
				Success = true,
				CommercialSpecific = new UpdateCommercialSpecificDto
				{
					SpecificName = updatedCommercialSpecific.Value.SpecificName,
					CommercialCategoryId = updatedCommercialSpecific.Value.CommercialCategoryId
				}
			};

		}
	}
}
