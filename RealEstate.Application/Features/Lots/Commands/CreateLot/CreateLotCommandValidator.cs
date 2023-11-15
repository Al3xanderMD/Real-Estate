using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Features.Lots.Commands.CreateLot
{
    public class CreateLotCommandValidator : AbstractValidator<CreateLotCommand>
    {
        public CreateLotCommandValidator()
        {
            RuleFor(p => p.LotArea)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.StreetFrontage)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.LotClassificationId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
