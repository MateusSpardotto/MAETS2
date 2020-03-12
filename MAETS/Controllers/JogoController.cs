using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using DAO.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCWebPresentationLayer.Models.Insert;
using MVCWebPresentationLayer.Models.Query;

namespace MVCWebPresentationLayer.Controllers
{
    [Authorize]
    public class JogoController : Controller
    {
        private IJogoService _jogoService;
        private IDesenvolvedorService _desenvolvedorService;

        public JogoController(IJogoService jogoService, IDesenvolvedorService desenvolvedorService)
        {
            this._jogoService = jogoService;
            this._desenvolvedorService = desenvolvedorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JogoInsertViewModel viewModel)
        {
            try
            {
                var configurationJogo = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<JogoInsertViewModel, JogoDTO>();
                });
                IMapper mapperJogo = configurationJogo.CreateMapper();
                JogoDTO jogo = mapperJogo.Map<JogoDTO>(viewModel);
                await _jogoService.Create(jogo);

                List<DesenvolvedorDTO> desenvolvedores = await _desenvolvedorService.GetDesenvolvedores();

                var configurationDesenvolvedor = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DesenvolvedorDTO, DesenvolvedorQueryViewModel>();
                });
                IMapper mapperDesenvolvedor = configurationDesenvolvedor.CreateMapper();

                List<DesenvolvedorQueryViewModel> dadosDesenvolvedor = mapperDesenvolvedor.Map<List<DesenvolvedorQueryViewModel>>(desenvolvedores);

                return View(dadosDesenvolvedor);
            }
            catch (MSException ex)
            {
                ViewBag.ValidationErrors = ex.Errors;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View();
        }


        public IActionResult Create()
        {
            return View();
        }
    }
}