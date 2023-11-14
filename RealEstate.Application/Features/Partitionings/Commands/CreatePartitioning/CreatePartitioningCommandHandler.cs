using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Partitionings.Commands.CreatePartitioning
{
    public class CreatePartitioningCommandHandler : IRequestHandler<CreatePartitioningCommand, CreatePartitioningCommandResponse>
    {
        private readonly IPartitioningRepository repository;
        public CreatePartitioningCommandHandler(IPartitioningRepository repository)
        {
            this.repository = repository;
        }
        public async Task<CreatePartitioningCommandResponse> Handle(CreatePartitioningCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePartitioningCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreatePartitioningCommandResponse
                {
                    Success = false,
                    ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var partitioning = Partitioning.CreatePartitioning(request.Type);

            if (!partitioning.IsSuccess)
            {
                return new CreatePartitioningCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { partitioning.Error }
                };
            }
            await repository.AddAsync(partitioning.Value);

            return new CreatePartitioningCommandResponse
            {
                Success = true,
                Partitioning = new CreatePartitioningDTO
                {
                    Id = partitioning.Value.Id,
                    Type = partitioning.Value.Type
                }
            };
        }
    }
}
