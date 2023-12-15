using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.HouseTypes.Commands.UpdateHouseType
{
	public class UpdateHouseTypeCommandHandler: IRequestHandler<UpdateHouseTypeCommand, UpdateHouseTypeCommandResponse>
	{
		private readonly IHouseTypeRepository repository;
		public UpdateHouseTypeCommandHandler(IHouseTypeRepository repository)
		{
			this.repository = repository;
		}

		public async Task<UpdateHouseTypeCommandResponse> Handle(UpdateHouseTypeCommand request, CancellationToken cancellationToken)
		{
			var houseType = await repository.FindByIdAsync(request.Id);
			var validator = new UpdateHouseTypeCommandValidator();
			var validatorResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new UpdateHouseTypeCommandResponse
				{
					Success = false,
					ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!houseType.IsSuccess)
			{
				return new UpdateHouseTypeCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { houseType.Error }
				};
			}

			houseType.Value.AttachType(request.Type);
			var updatedHouseType = await repository.UpdateAsync(houseType.Value);

			if (!updatedHouseType.IsSuccess)
			{
				return new UpdateHouseTypeCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedHouseType.Error }
				};
			}

			return new UpdateHouseTypeCommandResponse
			{
				Success = true,
				HouseType = new UpdateHouseTypeDto
				{
					Type = updatedHouseType.Value.Type
				}
			};
		}
	}
}
