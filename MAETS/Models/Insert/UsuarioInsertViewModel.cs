using DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Insert
{
    public class UsuarioInsertViewModel
    {
        
        [Required(ErrorMessage = "O nome deve ser informado.")]
        [StringLength(maximumLength: 60, MinimumLength = 5, ErrorMessage = "O nome deve conter de 5 a 60 caractéres.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O CPF deve ser informado.")]
        public string CPF { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Data de Nascimento deve ser informada.")]
        public DateTime DataNascimento { get; set; }
        [DisplayName("Tipo de Usuário")]
        public TipoUsuario TipoUsuario { get; set; }

        [DisplayName("País")]
        [Required(ErrorMessage = "O Pais deve ser selecionado.")]
        public Paises Pais { get; set; }
        
        [Required(ErrorMessage = "O Email deve ser informado.")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "A senha deve ser informada.")]
        [StringLength(maximumLength: 16, MinimumLength = 8, ErrorMessage ="A senha deve conter de 8 a 16 caracteres.")]
        public string Senha { get; private set; }

        [DisplayName("Confirmar Senha")]
        [Required(ErrorMessage = "Por favor, confirme sua senha.")]
        [Compare("Senha", ErrorMessage = "As senhas devem ser iguais.")]
        public string Confirmar_Senha { get; private set; }
    }
}
