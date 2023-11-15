using FluentValidation;

namespace RealEstate.Application.Features.Categories.Commands.CreateAgent
{
    public class CreateAgentCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAgentCommandValidator()
        {
            RuleFor(agent => agent.RegAuth.Email)
            .NotEmpty().WithMessage("Email is required");

            RuleFor(agent => agent.RegAuth.Password)
                .NotEmpty().WithMessage("Password is required");

            RuleFor(agent => agent.Url)
                .NotEmpty().WithMessage("URL address is required");

            RuleFor(agent => agent.AddressId.AddressName)
                .NotEmpty().WithMessage("Address name is required");

            RuleFor(agent => agent.AgentName)
                .NotEmpty().WithMessage("Agent name is required");

            RuleFor(agent => agent.Phone)
                .NotEmpty().WithMessage("Phone is required");
        }
    }
}
