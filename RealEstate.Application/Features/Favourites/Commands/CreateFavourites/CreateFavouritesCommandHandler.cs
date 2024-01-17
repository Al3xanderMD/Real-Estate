using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Favourites.Commands.CreateFavourites
{
    public class CreateFavouritesCommandHandler : IRequestHandler<CreateFavouritesCommand, CreateFavouritesCommandResponse>
    {
        private readonly IFavouritesRepository repository;

        public CreateFavouritesCommandHandler(IFavouritesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateFavouritesCommandResponse> Handle(CreateFavouritesCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFavouritesCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreateFavouritesCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var favourites = Favourite.Create(request.UserId, request.BasePostId);

            if(!favourites.IsSuccess)
            {
                return new CreateFavouritesCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { favourites.Error }
                };
            }

            await repository.AddAsync(favourites.Value);

            return new CreateFavouritesCommandResponse
            {
                Success = true,
                Favourites = new CreateFavouritesDto
                {

                    Id = favourites.Value.Id,
                    UserId = favourites.Value.UserId,
                    BasePostId = favourites.Value.BasePostId

                }
            };
        }
    }
}
