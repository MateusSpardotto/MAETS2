using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validators
{
    internal class GeneroValidator : AbstractValidator<GeneroDTO>
    {
        public GeneroValidator()
        {
            RuleFor(g => g.Nome).NotEmpty().WithMessage("Campo obrigatório!");
            RuleFor(g => g.Nome).MaximumLength(30).WithMessage("Máximo de 30 caracteres!");
            RuleFor(g => g.Nome).MinimumLength(5).WithMessage("Mínimo 5 caracteres!");
        }
    }
}
