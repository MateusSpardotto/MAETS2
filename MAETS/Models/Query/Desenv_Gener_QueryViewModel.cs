using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Query
{
    public class Desenv_Gener_QueryViewModel
    {
        public List<DesenvolvedorDTO> Desenvolvedores { get; set; }
        public List<GeneroDTO> Generos { get; set; }
    }
}
