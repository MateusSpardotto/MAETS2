using DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Insert
{
    public class JogoInsertViewModel
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public ClassificacaoIndicativa Calssificacao { get; set; }
        public virtual DesenvolvedorDTO DesenvolvedoraDTO { get; set; }
        public int DesenvolvedoraDTOID { get; set; }
        public virtual GeneroDTO GeneroDTO { get; set; }
        public int GeneroDTOID { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Especificacoes { get; set; }
    }
}
