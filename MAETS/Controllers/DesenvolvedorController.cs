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

namespace MVCWebPresentationLayer.Controllers
{
    [Authorize(Roles = "ADM")]
    public class DesenvolvedorController : Controller
    {
        private IDesenvolvedorService _desenvolvedorService;

        public DesenvolvedorController(IDesenvolvedorService desenvolvedorService)
        {
            this._desenvolvedorService = desenvolvedorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DesenvolvedorInsertViewModel viewModel)
        {
            try
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DesenvolvedorInsertViewModel, DesenvolvedorDTO>();
                });
                IMapper mapper = configuration.CreateMapper();
                DesenvolvedorDTO desenvolvedor = mapper.Map<DesenvolvedorDTO>(viewModel);
                await _desenvolvedorService.Create(desenvolvedor);

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