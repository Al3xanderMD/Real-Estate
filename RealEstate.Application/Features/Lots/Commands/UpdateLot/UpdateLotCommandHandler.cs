using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Lots.Commands.UpdateLot
{
	public class UpdateLotCommandHandler : IRequestHandler<UpdateLotCommand, UpdateLotCommandResponse>
	{
		private readonly ILotRepository repository;
		public UpdateLotCommandHandler(ILotRepository repository)
		{
			this.repository = repository;
		}
		public async Task<UpdateLotCommandResponse> Handle(UpdateLotCommand request, CancellationToken cancellationToken)
		{
			var lot = await repository.FindByIdAsync(request.Id);
			var validator = new UpdateLotCommandValidator();
			var validatorResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new UpdateLotCommandResponse
				{
					Success = false,
					ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!lot.IsSuccess)
			{
				return new UpdateLotCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { lot.Error }
				};
			}

			lot.Value.AttachLotArea(request.LotArea);
			lot.Value.AttachStreetFrontage(request.StreetFrontage);
			lot.Value.AttachLotClassificationId(request.LotClassificationId);
			lot.Value.AttachBasePostId(request.BasePostId);
			lot.Value.AttachBasePost(request.BasePost);
			lot.Value.AttachLotClassification(request.LotClassification);
			var updatedLot = await repository.UpdateAsync(lot.Value);

			if (!updatedLot.IsSuccess)
			{
				return new UpdateLotCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedLot.Error }
				};
			}

			return new UpdateLotCommandResponse
			{
				Success = true,
				Lot = new UpdateLotDto
				{
					BasePostId = updatedLot.Value.BasePostId,
					BasePost = updatedLot.Value.BasePost,
					LotClassificationId = updatedLot.Value.LotClassificationId,
					LotClassification = updatedLot.Value.LotClassification,
					LotArea = updatedLot.Value.LotArea,
					StreetFrontage = updatedLot.Value.StreetFrontage
				}
			};

		}
	}
}
