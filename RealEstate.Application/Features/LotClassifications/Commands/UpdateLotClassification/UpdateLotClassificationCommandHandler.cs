using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.LotClassifications.Commands.UpdateLotClassification
{
	public class UpdateLotClassificationCommandHandler: IRequestHandler<UpdateLotClassificationCommand, UpdateLotClassificationCommandResponse>
	{
		private readonly ILotClassificationRepository repository;
		public UpdateLotClassificationCommandHandler(ILotClassificationRepository repository)
		{
			this.repository = repository;
		}
		public async Task<UpdateLotClassificationCommandResponse> Handle(UpdateLotClassificationCommand request, CancellationToken cancellationToken)
		{
			var lotClassification = await repository.FindByIdAsync(request.Id);
			var validator = new UpdateLotClassificationCommandValidator();
			var validatorResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new UpdateLotClassificationCommandResponse
				{
					Success = false,
					ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!lotClassification.IsSuccess)
			{
				return new UpdateLotClassificationCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { lotClassification.Error }
				};
			}

			lotClassification.Value.AttachType(request.Type);
			var updatedLotClassification = await repository.UpdateAsync(lotClassification.Value);

			if (!updatedLotClassification.IsSuccess)
			{
				return new UpdateLotClassificationCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedLotClassification.Error }
				};
			}

			return new UpdateLotClassificationCommandResponse
			{
				Success = true,
				LotClassification = new UpdateLotClassificationDto
				{
					Type = updatedLotClassification.Value.Type
				}
			};
		}
	}

}
