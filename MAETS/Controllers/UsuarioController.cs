﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using Common;
using DAO;
using DAO.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using MVCWebPresentationLayer.Models.Insert;
using Microsoft.AspNetCore.Authentication;

namespace MVCWebPresentationLayer.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("first_request"))
            {
                HttpContext.Response.Cookies.Append("first_request", DateTime.Now.ToString());
                return Content("Welcome, new visitor!");
            }
            else
            {
                DateTime firstRequest = DateTime.Parse(HttpContext.Request.Cookies["first_request"]);
                return Content("Welcome back, user! You first visited us on: " + firstRequest.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioInsertViewModel viewModel)
        {
            try
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UsuarioInsertViewModel, UsuarioDTO>();
                });
                IMapper mapper = configuration.CreateMapper();
                UsuarioDTO usuario = mapper.Map<UsuarioDTO>(viewModel);
                await _usuarioService.Create(usuario);

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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string email, string senha)
        {

            if(await _usuarioService.Authenticate(email, senha) != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                props.IsPersistent = false;
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}