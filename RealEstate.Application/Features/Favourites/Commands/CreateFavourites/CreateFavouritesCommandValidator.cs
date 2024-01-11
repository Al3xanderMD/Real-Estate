using FluentValidation;

namespace RealEstate.Application.Features.Favourites.Commands.CreateFavourites
{
    public class CreateFavouritesCommandValidator : AbstractValidator<CreateFavouritesCommand>
    {
        public CreateFavouritesCommandValidator()
        {
            RuleFor(x => x.UserId)
             .NotEmpty()
             .WithMessage("User id is required")
             .NotNull()
             .WithMessage("User id is required");

            RuleFor(x => x.BasePostId)
                .NotEmpty()
                .WithMessage("Base post id is required")
                .NotNull()
                .WithMessage("Base post id is required");
            
        }
    }
}
