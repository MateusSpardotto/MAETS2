using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using DAO.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using MVCWebPresentationLayer.Models.Insert;

namespace MVCWebPresentationLayer.Controllers
{
    public class JogoController : Controller
    {
        private IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
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
            try
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<JogoInsertViewModel, JogoDTO>();
                });
                IMapper mapper = configuration.CreateMapper();
                JogoDTO jogo = mapper.Map<JogoDTO>(viewModel);
                await _jogoService.Create(jogo);

                return View();
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