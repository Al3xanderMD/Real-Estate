using FluentValidation;
using RealEstate.App.Models;

namespace RealEstate.App.Validators
{
    public class PostValidator : AbstractValidator<PostModel>
    {
        public PostValidator()
        {
            RuleFor(x => x.PropertyType).NotEmpty().WithMessage("Property Type is required!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required!");
            
            RuleFor(x => x.RoomCount).NotEmpty().WithMessage("Room Count is required!");
            RuleFor(x => x.BuildYear).NotEmpty().WithMessage("Build Year is required!");
             RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required!");
            RuleFor(x => x.Floor).NotEmpty().WithMessage("Floor is required!");
            RuleFor(x => x.FloorCount).NotEmpty().WithMessage("Floor Count is required!");
            
            //RuleFor(x => x.Area).NotEmpty().WithMessage("Area is required!");
            // RuleFor(x => x.UsefulSurface).NotEmpty().WithMessage("Useful Surface is required!");
            //RuleFor(x => x.LotType).NotEmpty().WithMessage("Lot Type is required!");
            // RuleFor(x => x.StreetFrontage).NotEmpty().WithMessage("Street Frontage is required!");
            //RuleFor(x => x.LotArea).NotEmpty().WithMessage("Lot Area is required!");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required!");
            
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required!");
            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("Contact Email is required!")
                .EmailAddress().WithMessage("Contact Email is not valid!");
            RuleFor(x => x.ContactPhone)
                .NotEmpty().WithMessage("Contact Phone is required!")
                .Matches(@"^(\+4)?07\d{8}$").WithMessage("Contact Phone is not valid!");
            RuleFor(x => x.ContactName).NotEmpty().WithMessage("Contact Name is required!");

        }
    }
}
