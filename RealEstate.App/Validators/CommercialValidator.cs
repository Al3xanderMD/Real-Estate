using FluentValidation;
using RealEstate.App.Operations.Create.Models;

namespace RealEstate.App.Validators
{
	public class CommercialValidator : AbstractValidator<CommercialViewModel>
	{
		public CommercialValidator()
		{

			RuleFor(x => x.usefulSurface)
				.NotEmpty().WithMessage("Useful Surface is required!");
			RuleFor(x => x.disponibility)
				.NotEmpty().WithMessage("Disponibility is required!");
			RuleFor(x => x.offerType)
				.NotEmpty().WithMessage("Offer type is required!");
		}
	}
}
