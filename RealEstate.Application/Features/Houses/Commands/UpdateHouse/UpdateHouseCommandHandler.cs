using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Houses.Commands.UpdateHouse
{
	public class UpdateHouseCommandHandler: IRequestHandler<UpdateHouseCommand, UpdateHouseCommandResponse>
	{
		private readonly IHouseRepository repository;
		public UpdateHouseCommandHandler(IHouseRepository repository)
		{
			this.repository = repository;
		}
		
		public async Task<UpdateHouseCommandResponse> Handle(UpdateHouseCommand request, CancellationToken cancellationToken)
		{
			var house = await repository.FindByIdAsync(request.Id);
			var validator = new UpdateHouseCommandValidator();
			var validatorResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new UpdateHouseCommandResponse
				{
					Success = false,
					ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!house.IsSuccess)
			{
				return new UpdateHouseCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { house.Error }
				};
			}

			house.Value.AttachRoomCount(request.RoomCount);
			house.Value.AttachFloorCount(request.FloorCount);
			house.Value.AttachUsefulSurface(request.UsefulSurface);
			house.Value.AttachLotArea(request.LotArea);
			house.Value.AttachBuildYear(request.BuildYear);
			house.Value.AttachComfort(request.Comfort);
			house.Value.AttachHouseTypeId(request.HouseTypeId);
			house.Value.AttachBasePostId(request.BasePostId);
			var updatedHouse = await repository.UpdateAsync(house.Value);

			if(!updatedHouse.IsSuccess)
			{
				return new UpdateHouseCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedHouse.Error }
				};
			}

			return new UpdateHouseCommandResponse
			{
				Success = true,
				House = new UpdateHouseDto
				{
					RoomCount = updatedHouse.Value.RoomCount,
					FloorCount = updatedHouse.Value.FloorCount,
					UsefulSurface = updatedHouse.Value.UsefulSurface,
					LotArea = updatedHouse.Value.LotArea,
					BuildYear = updatedHouse.Value.BuildYear,
					Comfort = updatedHouse.Value.Comfort,
					HouseTypeId = updatedHouse.Value.HouseTypeId,
					BasePostId = updatedHouse.Value.BasePostId
				}
			};
		}
	}
}
