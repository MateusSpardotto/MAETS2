using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validators
{
    internal class JogoValidator : AbstractValidator<JogoDTO>
    {
        public JogoValidator()
        {
            RuleFor(j => j.Nome).NotEmpty().WithMessage("Campo obrigatório!");
            RuleFor(j => j.Nome).MaximumLength(50).WithMessage("Máximo de 50 caracteres!");
            RuleFor(j => j.Nome).MinimumLength(2).WithMessage("Mínimo 2 caracteres!");
            RuleFor(j => j.Calssificacao).IsInEnum().WithMessage("Campo obrigatório!");
            RuleFor(j => j.DataLancamento).LessThan(DateTime.Now).WithMessage("Valor invalido!");
            RuleFor(j => j.Preco).NotEmpty().WithMessage("Campo obrigatório!");
            RuleFor(j => j.GeneroDTO).NotNull().WithMessage("Campo obrigatório!");
            RuleFor(j => j.Especificacoes).NotNull().WithMessage("Campo obrigatório!");
            RuleFor(j => j.Especificacoes).MaximumLength(450).WithMessage("Máximo de 450 caracteres!");
            RuleFor(j => j.Especificacoes).MinimumLength(50).WithMessage("Mínimo de 50 caracteres!");
        }
    }
}
