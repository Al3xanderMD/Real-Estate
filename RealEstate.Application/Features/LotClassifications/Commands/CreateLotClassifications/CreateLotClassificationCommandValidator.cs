using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Features.LotClassifications.CreateLotClassifications
{
    public class CreateLotClassificationCommandValidator : AbstractValidator<CreateLotClassificationCommand>
    {
        public CreateLotClassificationCommandValidator()
        {
            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
