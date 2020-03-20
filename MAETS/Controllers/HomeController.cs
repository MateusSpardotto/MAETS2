﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MAETS.Models;
using DTO;
using BLL.Impl;
using AutoMapper;
using MVCWebPresentationLayer.Models.Query;
using DAO.Interfaces;
using Common.Extensions;

namespace MAETS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IGeneroService _generoService;
        private IDesenvolvedorService _desenvolvedorService;

        public HomeController(ILogger<HomeController> logger, IGeneroService generoService, IDesenvolvedorService desenvolvedorService)
        {
            this._logger = logger;
            this._generoService = generoService;
            this._desenvolvedorService = desenvolvedorService;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
