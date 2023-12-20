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
			var hotelPension = await repository.FindByIdAsync(request.Id);
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

			hotelPension.Value.AttachBasePostId(request.BasePostId);
			hotelPension.Value.AttachRoomCount(request.RoomCount);
			hotelPension.Value.AttachRoomSurface(request.RoomSurface);
			hotelPension.Value.AttachUsefulSurface(request.UsefulSurface);
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
					BasePostId = updatedHotelPension.Value.BasePostId,
					RoomCount = updatedHotelPension.Value.RoomCount,
					RoomSurface = updatedHotelPension.Value.RoomSurface,
					UsefulSurface = updatedHotelPension.Value.UsefulSurface
				}
			};
		}
	}
}
