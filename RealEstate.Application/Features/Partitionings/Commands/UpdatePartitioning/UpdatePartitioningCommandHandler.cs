using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Partitionings.Commands.UpdatePartitioning
{
	public class UpdatePartitioningCommandHandler: IRequestHandler<UpdatePartitioningCommand, UpdatePartitioningCommandResponse>
	{
		private readonly IPartitioningRepository repository;
		public UpdatePartitioningCommandHandler(IPartitioningRepository repository)
		{
			this.repository = repository;
		}
		public async Task<UpdatePartitioningCommandResponse> Handle(UpdatePartitioningCommand request, CancellationToken cancellationToken)
		{
			var partitioning = await repository.FindByIdAsync(request.Id);
			var validator = new UpdatePartitioningCommandValidator();
			var validatorResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new UpdatePartitioningCommandResponse
				{
					Success = false,
					ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!partitioning.IsSuccess)
			{
				return new UpdatePartitioningCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { partitioning.Error }
				};
			}

			partitioning.Value.AttachType(request.Type);
			var updatedPartitioning = await repository.UpdateAsync(partitioning.Value);

			if(!updatedPartitioning.IsSuccess)
			{
				return new UpdatePartitioningCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedPartitioning.Error }
				};
			}

			return new UpdatePartitioningCommandResponse
			{
				Success = true,
				Partitioning = new UpdatePartitioningDto
				{
					Type = updatedPartitioning.Value.Type
				}
			};
		}
	}
}
