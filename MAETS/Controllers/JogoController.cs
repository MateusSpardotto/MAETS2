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
using Common.Extensions;

namespace MVCWebPresentationLayer.Controllers
{
    [Authorize]
    public class JogoController : Controller
    {
        private IJogoService _jogoService;
        private IDesenvolvedorService _desenvolvedorService;
        private IGeneroService _generoService;

        public JogoController(IJogoService jogoService, IDesenvolvedorService desenvolvedorService, IGeneroService generoService)
        {
            this._jogoService = jogoService;
            this._desenvolvedorService = desenvolvedorService;
            this._generoService = generoService;
        }

        public async Task<IActionResult> Index()
        {
            Dev_Gen_QueryViewModel devGenQVM = new Dev_Gen_QueryViewModel();
            
            try
            {
                List<GeneroDTO> generos = await _generoService.GetGeneros();
                List<DesenvolvedorDTO> desenvolvedores = await _desenvolvedorService.GetDesenvolvedores();
            
                devGenQVM.Generos = generos.ToViewModel<GeneroDTO, GeneroQueryViewModel>();
                devGenQVM.Desenvolvedores = desenvolvedores.ToViewModel<DesenvolvedorDTO, DesenvolvedorQueryViewModel>();
            
                return View(devGenQVM);
            }
            catch (Exception)
            {
                return View();
            }
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

        public async Task<IActionResult> Create()
        {
            List<DesenvolvedorDTO> desenvolvedores = await _desenvolvedorService.GetDesenvolvedores();
            //List<GeneroDTO> generos = await _generosService.GetGeneros();
            List<DesenvolvedorQueryViewModel> data =
                desenvolvedores.ToViewModel<DesenvolvedorDTO, DesenvolvedorQueryViewModel>();


            return View();

        }


    }
}