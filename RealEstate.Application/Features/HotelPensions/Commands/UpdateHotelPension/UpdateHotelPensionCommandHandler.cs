using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.HotelPensions.Commands.UpdateHotelPension
{
	public class UpdateHotelPensionCommandHandler: IRequestHandler<UpdateHotelPensionCommand, UpdateHotelPensionCommandResponse>
	{
		private readonly IHotelPensionRepository repository;
		public UpdateHotelPensionCommandHandler(IHotelPensionRepository repository)
		{
			this.repository = repository;
		}

		public async Task<UpdateHotelPensionCommandResponse> Handle(UpdateHotelPensionCommand request, CancellationToken cancellationToken)
		{
			var hotelPension = await repository.FindByIdAsync(request.BasePostId);
			var validator = new UpdateHotelPensionCommandValidator();
			var validatorResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new UpdateHotelPensionCommandResponse
				{
					Success = false,
					ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!hotelPension.IsSuccess)
			{
				return new UpdateHotelPensionCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { hotelPension.Error }
				};
			}

			hotelPension.Value.AttachRoomCount(request.RoomCount);
			hotelPension.Value.AttachRoomSurface(request.RoomSurface);
			hotelPension.Value.AttachUsefulSurface(request.UsefulSurface);
			hotelPension.Value.AttachUserId(request.UserId);
			hotelPension.Value.AttachTitlePost(request.TitlePost);
			hotelPension.Value.AttachPrice(request.Price);
			hotelPension.Value.AttachAddressId(request.AddressId);
			hotelPension.Value.AttachOfferType(request.OfferType);
			hotelPension.Value.AttachDescription(request.Description);

			var updatedHotelPension = await repository.UpdateAsync(hotelPension.Value);

			if (!updatedHotelPension.IsSuccess)
			{
				return new UpdateHotelPensionCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedHotelPension.Error }
				};
			}

			return new UpdateHotelPensionCommandResponse
			{
				Success = true,
				HotelPension = new UpdateHotelPensionDto
				{
					UserId = updatedHotelPension.Value.UserId,
					TitlePost = updatedHotelPension.Value.TitlePost,
					Price = updatedHotelPension.Value.Price,
					AddressId = updatedHotelPension.Value.AddressId,
					OfferType = updatedHotelPension.Value.OfferType,
					Description = updatedHotelPension.Value.Description,
					RoomCount = updatedHotelPension.Value.RoomCount,
					RoomSurface = updatedHotelPension.Value.RoomSurface,
					UsefulSurface = updatedHotelPension.Value.UsefulSurface
				}
			};
		}
	}
}
