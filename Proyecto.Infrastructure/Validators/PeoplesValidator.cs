using FluentValidation;
using Proyecto.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Infrastructure.Validators
{
    public class PeoplesValidator : AbstractValidator<PeoplesDto>
    {
        public PeoplesValidator()
        {
            RuleFor(peoples => peoples.Identificacion)
               .NotNull()
               .WithMessage("La identificación no puede ser nula");
        }
    }
}
