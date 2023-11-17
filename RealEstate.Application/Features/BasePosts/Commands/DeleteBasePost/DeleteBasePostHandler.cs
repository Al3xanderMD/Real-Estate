using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.BasePosts.Commands.DeleteBasePost
{
    public class DeleteBasePostHandler : IRequestHandler<DeleteBasePost, DeleteBasePostResponse>
    {
        private readonly IBasePostRepository repository;

        public DeleteBasePostHandler(IBasePostRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteBasePostResponse> Handle(DeleteBasePost request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.BasePostId);

            if(!result.IsSuccess)
            {
                return new DeleteBasePostResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteBasePostResponse
            {
                Success = true
            };
        }
    }
}
