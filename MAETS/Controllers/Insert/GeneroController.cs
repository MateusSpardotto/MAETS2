using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MVCWebPresentationLayer.Controllers.Genero
{
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
        public IActionResult Create()
        {
            _generoService.Create(new DTO.GeneroDTO());

            return View();
        }
    }
}