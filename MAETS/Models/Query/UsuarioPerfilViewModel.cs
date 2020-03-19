using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Query
{
    public class UsuarioPerfilViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<JogoDTO> Jogos { get; set; }
        public double Saldo { get; set; }
    }
}
