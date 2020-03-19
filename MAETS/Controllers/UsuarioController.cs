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
using MVCWebPresentationLayer.Models.Query;

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
        [HttpGet]
        public string VerificaEmail(string email)
        {
            return _usuarioService.VerificaEmail(email);
        }

        [HttpGet]
        public string VerificaSenha(string senha) 
        {
            return _usuarioService.VerificaSenha(senha);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {

           //this.User.Identity.

            if(await _usuarioService.Authenticate(email, senha) != null)
            {
                UsuarioDTO dto = await _usuarioService.Authenticate(email, senha);

                List<Claim> claims = new List<Claim>();

                if (dto.TipoUsuario == DTO.Enums.TipoUsuario.Adm)
                {
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, "ADM"),
                        new Claim(ClaimTypes.Name, dto.Email),
                        new Claim(ClaimTypes.Email, dto.Email)
                    };
                }
                else
                {
                    claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, "Comum"),
                        new Claim(ClaimTypes.Name, dto.Email),
                        new Claim(ClaimTypes.Email, dto.Email)
                    };
                }
               
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties()
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(2),

                };
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                
                
                ViewBag.UsuarioLogado = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Procurar(string searchString)
        {
            UsuarioDTO user = await _usuarioService.GetUserForEmail(searchString);
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioDTO, UsuarioPerfilViewModel>();
            });
            IMapper mapper = configuration.CreateMapper();
            UsuarioPerfilViewModel usuario = mapper.Map<UsuarioPerfilViewModel>(user);

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}