using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class JogoDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public ClassificacaoIndicativa Calssificacao { get; set; }
        public virtual DesenvolvedorDTO DesenvolvedoraDTO { get; set; }
        public int DesenvolvedoraDTOID { get; set; }
        public virtual GeneroDTO GeneroDTO { get; set; }
        public int GeneroDTOID { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Especificacoes { get; set; }
        public virtual UsuarioDTO UsuarioDTO { get; set; }
        public virtual ICollection<UsuarioDTO> Usuarios { get; set; }
    }
}
