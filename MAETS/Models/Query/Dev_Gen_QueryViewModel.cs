using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Query
{
    public class Dev_Gen_QueryViewModel
    {
        public List<GeneroQueryViewModel> Generos { get; set; }
        public List<DesenvolvedorQueryViewModel> Desenvolvedores { get; set; }
    }
}
