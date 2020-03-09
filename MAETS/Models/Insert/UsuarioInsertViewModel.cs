using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Insert
{
    public class UsuarioInsertViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Pais { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Confirmar_Senha { get; set; }
    }
}
