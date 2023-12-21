using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

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
			var lot = await repository.FindByIdAsync(request.BasePostId);
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
            lot.Value.AttachUserId(request.UserId);
            lot.Value.AttachTitlePost(request.TitlePost);
            lot.Value.AttachPrice(request.Price);
            lot.Value.AttachAddressId(request.AddressId);
            lot.Value.AttachOfferType(request.OfferType);
			lot.Value.AttachDescription(request.Description);

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
					UserId = updatedLot.Value.UserId,
					TitlePost = updatedLot.Value.TitlePost,
					Price = updatedLot.Value.Price,
					AddressId = updatedLot.Value.AddressId,
					OfferType = updatedLot.Value.OfferType,
					Description = updatedLot.Value.Description,
					LotClassificationId = updatedLot.Value.LotClassificationId,
					LotArea = updatedLot.Value.LotArea,
					StreetFrontage = updatedLot.Value.StreetFrontage
				}
			};

		}
	}
}
