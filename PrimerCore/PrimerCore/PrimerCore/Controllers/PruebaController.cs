using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerCore.Controllers
{
    public class PruebaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
