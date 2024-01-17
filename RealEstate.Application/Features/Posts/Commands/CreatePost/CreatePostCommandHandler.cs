using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Posts.Commands.CreatePost
{
	public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostCommandResponse>
	{
		private readonly IPostRepository repository;
		public CreatePostCommandHandler(IPostRepository repository)
		{
			this.repository = repository;
		}

		public async Task<CreatePostCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreatePostCommandValidator();
			var validationResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validationResult.IsValid)
			{
				return new CreatePostCommandResponse
				{
					Success = false,
					ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			var post = Post.Create(request.BasePostId, request.Type);

			if (!post.IsSuccess)
			{
				return new CreatePostCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { post.Error }
				};
			}

			await repository.AddAsync(post.Value);

			return new CreatePostCommandResponse
			{
				Success = true,
				Post = new CreatePostDto
				{
					BasePostId = post.Value.BasePostId,
					Type = post.Value.Type
				}
			};	
		}
	}
}
