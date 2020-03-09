using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAO.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using MVCWebPresentationLayer.Models.Insert;

namespace MVCWebPresentationLayer.Controllers
{
    public class UsuarioController : Controller
    {
        private IJogoService _jogoService;

        public UsuarioController(IJogoService jogoService)
        {
            this._jogoService = jogoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JogoInsertViewModel viewModel)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DesenvolvedorInsertViewModel, JogoDTO>();
            });
            IMapper mapper = configuration.CreateMapper();
            JogoDTO jogo = mapper.Map<JogoDTO>(viewModel);
            await _jogoService.Create(jogo);

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}