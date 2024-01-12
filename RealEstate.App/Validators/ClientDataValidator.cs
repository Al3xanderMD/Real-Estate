using FluentValidation;
using RealEstate.App.Models;

namespace RealEstate.App.Validators
{
	public class ClientDataValidator : AbstractValidator<ClientDataViewModel>
	{
		public ClientDataValidator()
		{
			RuleFor(x => x.name)
				.NotEmpty().WithMessage("Name is required!")
				.Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

			RuleFor(x => x.phoneNumber)
				.NotEmpty().WithMessage("Phone number is required!")
				.Matches(@"^(\+4)?07\d{8}$").WithMessage("Phone number is not valid!");

			RuleFor(x => x.email)
				.NotEmpty().WithMessage("Email is required!")
				.EmailAddress().WithMessage("Email is not valid!");


		}
	}
}
