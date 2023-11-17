using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.DeleteCommercialSpecific
{
    public class DeleteCommercialSpecificHandler : IRequestHandler<DeleteCommercialSpecific, DeleteCommercialSpecificResponse>
    {
        private readonly ICommercialSpecificRepository repository;

        public DeleteCommercialSpecificHandler(ICommercialSpecificRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteCommercialSpecificResponse> Handle(DeleteCommercialSpecific request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.CommercialSpecificId);

            if(!result.IsSuccess)
            {
                return new DeleteCommercialSpecificResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteCommercialSpecificResponse
            {
                Success = true
            };
        }
    }
}
