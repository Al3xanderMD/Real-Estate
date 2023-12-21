using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Commercials.Commands.DeleteCommercial
{
    public class DeleteCommercialHandler : IRequestHandler<DeleteCommercial, DeleteCommercialResponse>
    {
        private readonly ICommercialRepository repository;

        public DeleteCommercialHandler(ICommercialRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteCommercialResponse> Handle(DeleteCommercial request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.BasePostId);

            if(!result.IsSuccess)
            {
                return new DeleteCommercialResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteCommercialResponse
            {
                Success = true
            };
        }
    }
}
