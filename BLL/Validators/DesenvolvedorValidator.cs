using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validators
{
    internal class DesenvolvedorValidator : AbstractValidator<DesenvolvedorDTO>
    {
        public DesenvolvedorValidator()
        {
            RuleFor(d => d.Nome).NotEmpty().WithMessage("Campo obrigatório!");
            RuleFor(d => d.Nome).MaximumLength(60).WithMessage("Máximo de 60 caracteres!");
            RuleFor(d => d.Nome).MinimumLength(5).WithMessage("Mínimo 5 caracteres!");
            RuleFor(d => d.PaisOrigem).NotNull().WithMessage("Campo obrigatório!");
        }
    }
}
