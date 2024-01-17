using MediatR;
using RealEstate.Application.Persistence;
using System.Runtime.CompilerServices;

namespace RealEstate.Application.Features.Posts.Commands.DeletePost
{
	public class DeletePostHandler : IRequestHandler<DeletePost, DeletePostResponse>
	{
		private readonly IPostRepository repository;

		public DeletePostHandler(IPostRepository repository)
		{
			this.repository = repository;
		}

		public async Task<DeletePostResponse> Handle(DeletePost request, CancellationToken cancellationToken)
		{
			var result = await repository.DeleteIntAsync(request.Id);

			if (!result.IsSuccess)
			{
				return new DeletePostResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { result.Error }
				};
			}

			return new DeletePostResponse
			{
				Success = true
			};
		}
	}
}

