using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Commercials.Commands.UpdateCommercial
{
	public class UpdateCommercialCommandHandler: IRequestHandler<UpdateCommercialCommand, UpdateCommercialCommandResponse>
	{
		private readonly ICommercialRepository repository;

		public UpdateCommercialCommandHandler(ICommercialRepository repository)
		{
			this.repository = repository;
		}
		public async Task<UpdateCommercialCommandResponse> Handle(UpdateCommercialCommand request, CancellationToken cancellationToken)
		{
			var commercial = await repository.FindByIdAsync(request.Id);
			var validator = new UpdateCommercialCommandValidator();
			var validatorResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new UpdateCommercialCommandResponse
				{
					Success = false,
					ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!commercial.IsSuccess)
			{
				return new UpdateCommercialCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { commercial.Error }
				};
			}

			commercial.Value.AttachUsefulSurface(request.UsefulSurface);
			commercial.Value.AttachDisponibility(request.Disponibility);
			commercial.Value.AttachBasePostId(request.BasePostId);
			commercial.Value.AttachCommercialSpecificId(request.CommercialSpecificId);
			var updatedCommercial = await repository.UpdateAsync(commercial.Value);

			if (!updatedCommercial.IsSuccess)
			{
				return new UpdateCommercialCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedCommercial.Error }
				};
			}

			return new UpdateCommercialCommandResponse
			{
				Success = true,
				Commercial = new UpdateCommercialDto
				{
					UsefulSurface = updatedCommercial.Value.UsefulSurface,
					Disponibility = updatedCommercial.Value.Disponibility,
					BasePostId = updatedCommercial.Value.BasePostId,
					CommercialSpecificId = updatedCommercial.Value.CommercialSpecificId
				}
			};
		}
	}
}
