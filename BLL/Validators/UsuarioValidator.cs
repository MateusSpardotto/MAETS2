using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validators
{
    class UsuarioValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Nome).NotEmpty().WithMessage("Campo obrigatório!");
            RuleFor(u => u.Nome).MaximumLength(60).WithMessage("Máximo de 60 caracteres!");
            RuleFor(u => u.Nome).MinimumLength(5).WithMessage("Mínimo 5 caracteres!");
            RuleFor(u => u.Pais).NotNull().WithMessage("Campo obrigatório!");
            RuleFor(u => u.Senha).NotEmpty().WithMessage("Campo obrigatório!");
            RuleFor(u => u.Senha).MaximumLength(16).WithMessage("Máximo 16 caracteres!");
            RuleFor(u => u.Senha).MinimumLength(8).WithMessage("Mínimo 8 caracteres!");
            RuleFor(u => u.TipoUsuario).NotNull().WithMessage("Campo obrigatório!");
            RuleFor(u => u.DataNascimento).LessThan(DateTime.Now).WithMessage("Valor inválido!");
            RuleFor(u => u.CPF).MaximumLength(14).WithMessage("Valor inválido!");
            RuleFor(u => u.CPF).NotEmpty().WithMessage("Campo obrigatório!");
        }
    }
}
