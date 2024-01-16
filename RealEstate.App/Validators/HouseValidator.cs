using FluentValidation;
using RealEstate.App.Operations.Create.Models;

namespace RealEstate.App.Validators
{
	public class HouseValidator : AbstractValidator<HouseViewModel>
	{
		public HouseValidator()
		{
			RuleFor(x => x.roomCount)
				.NotEmpty().WithMessage("Room count is required!");

			RuleFor(x => x.floorCount)
				.NotEmpty().WithMessage("Floor count is required!");

			RuleFor(x => x.buildYear)
				.NotEmpty().WithMessage("Build year is required!") ;

			RuleFor(x => x.offerType)
				.NotEmpty().WithMessage("Offer type is required!");

			RuleFor(x => x.usefulSurface)
				.NotEmpty().WithMessage("Useful Surface is required!");

			RuleFor(x => x.lotArea)
				.NotEmpty().WithMessage("Lot Area is required!");
		}
	}
}
