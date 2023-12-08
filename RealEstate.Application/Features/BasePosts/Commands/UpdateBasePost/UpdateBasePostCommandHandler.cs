using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.BasePosts.Commands.UpdateBasePost
{
	public class UpdateBasePostCommandHandler: IRequestHandler<UpdateBasePostCommand, UpdateBasePostCommandResponse>
	{
		private readonly IBasePostRepository repository;
		public UpdateBasePostCommandHandler(IBasePostRepository repository)
		{
			this.repository = repository;
		}
		public async Task<UpdateBasePostCommandResponse> Handle(UpdateBasePostCommand request, CancellationToken cancellationToken)
		{
			var basePost = await repository.FindByIdAsync(request.Id);
			var validator = new UpdateBasePostCommandValidator();
			var validatorResult = await validator.ValidateAsync(request, cancellationToken);

			if (!validatorResult.IsValid)
			{
				return new UpdateBasePostCommandResponse
				{
					Success = false,
					ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
				};
			}

			if (!basePost.IsSuccess)
			{
				return new UpdateBasePostCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { basePost.Error }
				};
			}

		    basePost.Value.AttachUserId(request.UserId);
			basePost.Value.AttachClient(request.Client);
			basePost.Value.AttachTitlePost(request.TitlePost);
			basePost.Value.AttachImages(request.Images);
			basePost.Value.AttachOfferType(request.OfferType);
			basePost.Value.AttachPrice(request.Price);
			basePost.Value.AttachAddressId(request.AddressId);
			basePost.Value.AttachAddress(request.Address);
			basePost.Value.AttachDescription(request.Descripion);
			var updatedBasePost = await repository.UpdateAsync(basePost.Value);

			if (!updatedBasePost.IsSuccess)
			{
				return new UpdateBasePostCommandResponse
				{
					Success = false,
					ValidationErrors = new List<string>() { updatedBasePost.Error }
				};
			}

			return new UpdateBasePostCommandResponse
			{
				Success = true,
				BasePost = new UpdateBasePostDto
				{
					UserId = updatedBasePost.Value.UserId,
					Client = updatedBasePost.Value.User,
					TitlePost = updatedBasePost.Value.TitlePost,
					Images = updatedBasePost.Value.Images,
					OfferType = updatedBasePost.Value.OfferType,
					Price = updatedBasePost.Value.Price,
					AddressId = updatedBasePost.Value.AddressId,
					Address = updatedBasePost.Value.Address,
					Descripion = updatedBasePost.Value.Descripion
				}
			};
		}
	}
}
