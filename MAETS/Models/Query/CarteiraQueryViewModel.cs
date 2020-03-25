using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Query
{
    public class CarteiraQueryViewModel
    {
        public string NomeUsuario { get; set; }
        public double Saldo { get; private set; }
    }
}
