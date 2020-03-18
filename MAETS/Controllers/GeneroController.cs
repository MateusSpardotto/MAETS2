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
using MVCWebPresentationLayer.Models;
using MVCWebPresentationLayer.Models.Query;

namespace MVCWebPresentationLayer.Controllers.Genero
{
    [Authorize(Roles = "ADM")]
    public class GeneroController : Controller
    {
        private IGeneroService _generoService; 

        public GeneroController(IGeneroService generoService)
        {
            this._generoService = generoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GeneroInsertViewModel viewModel)
        {
            try
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<GeneroInsertViewModel, GeneroDTO>();
                });
                IMapper mapper = configuration.CreateMapper();
                GeneroDTO genero = mapper.Map<GeneroDTO>(viewModel);
                await _generoService.Create(genero);

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