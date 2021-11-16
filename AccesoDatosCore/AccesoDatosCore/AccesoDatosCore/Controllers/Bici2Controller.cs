using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class Bici2Controller : Controller
    {
        private Bici bici2;
        public Bici2Controller(Bici bici2)
        {
            this.bici2 = bici2;
        }
        public IActionResult Index()
        {
            return View(this.bici2);
        }
    }
}
