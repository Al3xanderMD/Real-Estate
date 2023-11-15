using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.LotClassifications.Command.DeleteLotClassification
{
    public class DeleteLotClassificationHandler : IRequestHandler<DeleteLotClassification, DeleteLotClassificationResponse>
    {
        private readonly ILotClassificationRepository repository;

        public DeleteLotClassificationHandler(ILotClassificationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteLotClassificationResponse> Handle(DeleteLotClassification request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new DeleteLotClassificationResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteLotClassificationResponse
            {
                Success = true
            };
        }
    }
}
