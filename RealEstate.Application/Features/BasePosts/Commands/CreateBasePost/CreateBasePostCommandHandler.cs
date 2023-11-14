using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Categories.Commands.CreateBasePost
{
    public class CreateBasePostCommandHandler : IRequestHandler<CreateBasePostCommand, CreateBasePostCommandResponse>
    {
        private readonly IBasePostRepository repository;

        public CreateBasePostCommandHandler(IBasePostRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateBasePostCommandResponse> Handle(CreateBasePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBasePostCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validatorResult.IsValid)
            {
                return new CreateBasePostCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var basePost = BasePost.Create(request.UserId, request.TitlePost, request.Price, request.AddressId, request.OfferType);

            if(!basePost.IsSuccess)
            {
                return new CreateBasePostCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { basePost.Error }
                };
            }

            await repository.AddAsync(basePost.Value);

            return new CreateBasePostCommandResponse
            {
                Success = true,
                BasePost = new CreateBasePostDto
                {
                    BasePostId = basePost.Value.BasePostId,
                    TitlePost = basePost.Value.TitlePost,
                    Price = basePost.Value.Price,
                    AddressId = basePost.Value.AddressId,
                    OfferType = basePost.Value.OfferType,
                    UserId = basePost.Value.UserId
                }
            };
        }
    }
}
    
