﻿using DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Insert
{
    public class JogoInsertViewModel
    {
        [Required(ErrorMessage = "O nome deve ser informado.")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "O nome deve conter de 5 a 50 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Preço")]
        [Required(ErrorMessage = "O preço deve ser informado.")]
        public double Preco { get; set; }
        
        public ClassificacaoIndicativa Classificacao { get; set; }
        public int DesenvolvedorDTOID { get; set; }
        public int GeneroDTOID { get; set; }
        [DisplayName("Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [DisplayName("Especificações")]
        [Required(ErrorMessage = "As especificações devem ser informado.")]
        [StringLength(maximumLength: 450, MinimumLength = 50, ErrorMessage = "Minimo de 50 e máximo de 450 caractéres.")]
        public string Especificacoes { get; set; }
    }
}
