using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.LotClassifications.CreateLotClassifications
{
    public class CreateLotClassificationCommandHandler : IRequestHandler<CreateLotClassificationCommand, CreateLotClassificationCommandResponse>
    {
        private readonly ILotClassificationRepository repository;

        public CreateLotClassificationCommandHandler(ILotClassificationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateLotClassificationCommandResponse> Handle(CreateLotClassificationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLotClassificationCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreateLotClassificationCommandResponse
                {
                    Success = false,
                    ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var lotClassification = LotClassification.Create(request.Type);

            if (!lotClassification.IsSuccess)
            {
                return new CreateLotClassificationCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { lotClassification.Error }
                };
            }

            await repository.AddAsync(lotClassification.Value);

            return new CreateLotClassificationCommandResponse
            {
                Success = true,
                LotClassification = new CreateLotClassificationDTO
                {
                    Id = lotClassification.Value.Id,
                    Type = lotClassification.Value.Type
                }
            };
        }
    }
}
