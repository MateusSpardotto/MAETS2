using DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Query
{
    public class FiltroViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public ClassificacaoIndicativa Classificacao { get; set; }

        [DisplayName("Desenvolvedor")]
        public string DesenvolvedorDTONome { get; set; }

        [DisplayName("Desenvolvedor")]
        public string GeneroDTONome { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Especificacoes { get; set; }
    }
}
