using DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCWebPresentationLayer.Models
{
    public class GeneroInsertViewModel
    {
        [Required(ErrorMessage = "Nome do Gênero deve ser informado.")]
        [StringLength(maximumLength: 30, MinimumLength = 5, ErrorMessage = "O nome do gênero deve conter de 5 a 30 caracteres.")]
        public string Nome { get; set; }
    }
}
