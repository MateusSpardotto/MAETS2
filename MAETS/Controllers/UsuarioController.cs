using System;
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
            return View();
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

        [HttpPost]
        public async Task<ActionResult> Login(string email, string senha)
        {
            if (_usuarioService.Authenticate(email, senha) == null)
            {
                return View();
            }

            try
            {
                var claims = new[] { new Claim(ClaimTypes.Name, email), new Claim(ClaimTypes.Role, "Authenticate") };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //Response.Cookies.Append("NomeDoCookie", ID.ToString()); 
                //Request.Cookies["NomeDoCookie"]

                //await MContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                //HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Cliente");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }

            return View();
        }
    }
}