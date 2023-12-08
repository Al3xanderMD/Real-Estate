using MediatR;
using RealEstate.Application.Features.Apartments.Commands.UpdateApartament;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Apartments.Commands.UpdateApartment
{
	public class UpdateApartamentCommandHandler : IRequestHandler<UpdateApartmentCommand, UpdateApartmentCommandResponse>
	{
		private readonly IApartmentRepository repository;

		public UpdateApartamentCommandHandler(IApartmentRepository repository)
		{
			this.repository = repository;
		}
		public async Task<UpdateApartmentCommandResponse> Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
		{
			var apartment = await repository.FindByIdAsync(request.Id);
			var validator = new UpdateApartmentCommandValidator();
			var validatorResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new UpdateApartmentCommandResponse
				{
					Success = false,
					ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!apartment.IsSuccess)
			{
				return new UpdateApartmentCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { apartment.Error }
				};
			}

			apartment.Value.AttachRoomCount(request.RoomCount);
			apartment.Value.AttachComfort(request.Comfort);
			apartment.Value.AttachFloor(request.Floor);
			apartment.Value.AttachUsefulSurface(request.UsefulSurface);
			apartment.Value.AttachBuildYear(request.BuildYear);
			apartment.Value.AttachBasePostId(request.BasePostId);
			apartment.Value.AttachPartitioningId(request.PartitioningId);
			var updatedApartment = await repository.UpdateAsync(apartment.Value);

			if (!updatedApartment.IsSuccess)
			{
				return new UpdateApartmentCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedApartment.Error }
				};
			}

			return new UpdateApartmentCommandResponse
			{
				Success = true,
				Apartment = new UpdateApartmentDto
				{
					RoomCount = updatedApartment.Value.RoomCount,
					Comfort = updatedApartment.Value.Comfort,
					Floor = updatedApartment.Value.Floor,
					UsefulSurface = updatedApartment.Value.UsefulSurface,
					BuildYear = updatedApartment.Value.BuildYear,
					BasePostId = updatedApartment.Value.BasePostId,
					PartitioningId = updatedApartment.Value.PartitioningId
				}
			};

		}
	}

}
