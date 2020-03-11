using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Insert
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O Email deve ser informado.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }
       
        [Required(ErrorMessage = "A senha deve ser informada.")]
        public string Senha { get; set; }
    }
}
