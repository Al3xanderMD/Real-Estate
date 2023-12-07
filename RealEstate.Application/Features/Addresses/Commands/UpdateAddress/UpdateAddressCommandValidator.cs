using FluentValidation;

namespace RealEstate.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator() 
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .NotEqual(Guid.Empty);

            RuleFor(p => p.AddressName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed 200 characters.");
        }
    }
}
