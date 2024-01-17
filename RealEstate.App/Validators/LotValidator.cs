using FluentValidation;
using RealEstate.App.Operations.Create.Models;

namespace RealEstate.App.Validators
{
	public class LotValidator : AbstractValidator<LotViewModel>
	{
		public LotValidator()
		{
			RuleFor(x => x.offerType)
				.NotEmpty().WithMessage("Offer type is required!");
			RuleFor(x => x.streetFrontage)
				.NotEmpty().WithMessage("Street Frontage is required!");
			RuleFor(x => x.lotArea)
				.NotEmpty().WithMessage("Lot Area is required!");

		}
	}
}
