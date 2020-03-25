using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MAETS.Models;
using DTO;
using BLL.Impl;
using AutoMapper;
using MVCWebPresentationLayer.Models.Query;
using DAO.Interfaces;
using Common.Extensions;
using MVCWebPresentationLayer.Models.Insert;

namespace MVCWebPresentationLayer.Controllers
{
    public class CompraController : Controller
    {
        private IJogoService _jogoService;
        private IGeneroService _generoService;
        private IDesenvolvedorService _desenvolvedorService;

        public CompraController(IJogoService jogoService, IGeneroService generoService, IDesenvolvedorService desenvolvedorService)
        {
            this._jogoService = jogoService;
            this._generoService = generoService;
            this._desenvolvedorService = desenvolvedorService;
        }

        public async Task<IActionResult> ComprarJogo(int jogoID)
        {
            List<JogoDTO> jogoDTO = await _jogoService.GetJogoById(jogoID);
            List<FiltroViewModel> jogosView = jogoDTO.ToViewModel<JogoDTO, FiltroViewModel>();

            for (int i = 0; i < jogosView.Count; i++)
            {
                jogosView[i].DesenvolvedorDTONome = await _desenvolvedorService.GetDesenvolvedorById(jogoDTO[i].DesenvolvedorDTOID);
                jogosView[i].GeneroDTONome = await _generoService.GetGeneroById(jogoDTO[i].GeneroDTOID);
            }

            return View(jogosView);
        }
    }
}