using FluentValidation;

namespace RealEstate.Application.Features.Categories.Commands.CreateAgent
{
    public class CreateAgentCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAgentCommandValidator()
        {
            RuleFor(agent => agent.UserId)
            .NotEmpty().WithMessage("UserId is required");

            RuleFor(agent => agent.Url)
                .NotEmpty().WithMessage("URL address is required");

            RuleFor(agent => agent.AddressId)
                .NotEmpty().WithMessage("AddressId is required");

            RuleFor(agent => agent.AgentName)
                .NotEmpty().WithMessage("Agent name is required");

            RuleFor(agent => agent.Phone)
                .NotEmpty().WithMessage("Phone is required");
        }
    }
}
