using DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Insert
{
    public class DesenvolvedorInsertViewModel
    {
        [Required(ErrorMessage ="O nome deve ser informado.")]
        [StringLength(maximumLength: 60, MinimumLength = 5, ErrorMessage ="O nome deve conter de 5 a 60 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage ="Selecione o País de Origem.")]
        public Paises PaisOrigem { get; set; }
    }
}
