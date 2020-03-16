using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebPresentationLayer.Models.Query
{
    public class DesenvolvedorQueryViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public List<DesenvolvedorQueryViewModel> MappingThis(List<DesenvolvedorDTO> desenvolvedores)
        {
            var configurationDesenvolvedor = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DesenvolvedorDTO, DesenvolvedorQueryViewModel>();
            });
            IMapper mapperDesenvolvedor = configurationDesenvolvedor.CreateMapper();

            List<DesenvolvedorQueryViewModel> dadosDesenvolvedor = mapperDesenvolvedor
                .Map<List<DesenvolvedorQueryViewModel>>(desenvolvedores);

            return dadosDesenvolvedor;
        }
    }
}
