using FluentValidation;
using RealEstate.App.Operations.Create.Models;

namespace RealEstate.App.Validators
{
	public class HotelPensionValidator : AbstractValidator<HotelPensionViewModel>
	{
		public HotelPensionValidator()
		{
			RuleFor(x => x.roomCount)
				.NotEmpty().WithMessage("Room count is required!");

			//RuleFor(x => x.offerType)
			//	.NotEmpty().WithMessage("Offer type is required!");

			RuleFor(x => x.usefulSurface)
				.NotEmpty().WithMessage("Useful Surface is required!");

			RuleFor(x => x.roomSurface)
				.NotEmpty().WithMessage("Room Surface is required!");
		}	

	}
}
