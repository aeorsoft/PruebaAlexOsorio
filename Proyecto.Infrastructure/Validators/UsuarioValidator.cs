using FluentValidation;
using Proyecto.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Infrastructure.Validators
{
    class UsuarioValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioValidator()
        {
            RuleFor(usuarios => usuarios.Email)
               .NotNull()
               .WithMessage("El usuario es obligatorio");
        }
    }
}
