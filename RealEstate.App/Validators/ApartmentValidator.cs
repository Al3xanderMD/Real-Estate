using FluentValidation;
using RealEstate.App.Operations.Create.Models;

namespace RealEstate.App.Validators
{
	public class ApartmentValidator : AbstractValidator<ApartmentViewModel>
	{
		public ApartmentValidator()
		{
			
			RuleFor(x => x.roomCount)
				.NotEmpty().WithMessage("Room count is required!");

			RuleFor(x => x.floor)
				.NotEmpty().WithMessage("Floor number is required!");

			RuleFor(x => x.buildYear)
				.NotEmpty().WithMessage("ConstructionYear is required!")
				.GreaterThan(0).WithMessage("ConstructionYear must be greater than 0!");

			RuleFor(x => x.comfort)
				.NotEmpty().WithMessage("Comfort is required!");

			RuleFor(x=>x.offerType)
				.NotEmpty().WithMessage("Offer type is required!");

			RuleFor(x => x.usefulSurface)
				.NotEmpty().WithMessage("Useful Surface is required!");
		}
	}
}
