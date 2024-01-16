using FluentValidation;
using RealEstate.App.Models;
using RealEstate.App.Operations.Fetch.Models;

namespace RealEstate.App.Validators
{
	public class PostModelValidator : AbstractValidator<BasePostViewModel>
	{
		public PostModelValidator()
		{
			//RuleFor(x => x.postType)
			//	.NotNull().WithMessage("Property type is required!")
			//	.NotEqual(default(string)).WithMessage("Property type is required!");

			RuleFor(x => x.title)
				.NotEmpty().WithMessage("Title is required!")
				.Length(2, 50).WithMessage("Title must be between 2 and 50 characters.");

			RuleFor(x => x.description)
				.NotEmpty().WithMessage("Description is required!")
				.Length(2, 500).WithMessage("Description must be between 2 and 500 characters.");

			RuleFor(x => x.price)
				.NotEmpty().WithMessage("Price is required!")
				.GreaterThan(0).WithMessage("Price must be greater than 0!");

			//RuleFor(x => x.RoomCount)
			//	.NotEmpty().WithMessage("Room count is required!");

			//RuleFor(x => x.Floor)
			//	.NotEmpty().WithMessage("Floor number is required!");

			//RuleFor(x => x.FloorCount)
			//	.NotEmpty().WithMessage("Floor count is required!");
			//RuleFor(x => x.BuildYear)
			//	.NotEmpty().WithMessage("ConstructionYear is required!")
			//	.GreaterThan(0).WithMessage("ConstructionYear must be greater than 0!");


		}
	}
}
