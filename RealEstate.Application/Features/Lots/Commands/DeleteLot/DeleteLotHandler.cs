using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Lots.Commands.DeleteLot
{
    public class DeleteLotHandler : IRequestHandler<DeleteLot, DeleteLotResponse>
    {
        private readonly ILotRepository repository;

        public DeleteLotHandler(ILotRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteLotResponse> Handle(DeleteLot request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new DeleteLotResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteLotResponse
            {
                Success = true
            };
        }
    }
}
