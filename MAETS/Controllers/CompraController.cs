using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCWebPresentationLayer.Controllers
{
    public class CompraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ComprarJogo(int jogoID)
        {
            return View();
        }
    }
}