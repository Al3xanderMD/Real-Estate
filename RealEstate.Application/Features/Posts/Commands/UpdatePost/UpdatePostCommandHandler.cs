using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Posts.Commands.UpdatePost
{
	public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostCommandResponse>
	{
		private readonly IPostRepository repository;

		public UpdatePostCommandHandler(IPostRepository repository)
		{
			this.repository = repository;
		}

		public async Task<UpdatePostCommandResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
		{	
			var post = await repository.FindByIdAsync(request.PostId);
			var validator = new UpdatePostCommandValidator();
			var validationResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validationResult.IsValid)
			{
				return new UpdatePostCommandResponse
				{
					Success = false,
					ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!post.IsSuccess) 
			{
				return new UpdatePostCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { post.Error }
				};
			}

			post.Value.attachType(request.Type);
			var updatedPost = await repository.UpdateAsync(post.Value);

			if (!updatedPost.IsSuccess) 
			{
				return new UpdatePostCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedPost.Error }
				};
			}

			return new UpdatePostCommandResponse
			{
				Success = true,
				Post = new UpdatePostDto
				{
					PostId = updatedPost.Value.BasePostId,
					Type = updatedPost.Value.Type
				}
			};
		}
	}
}
