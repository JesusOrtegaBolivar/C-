using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class Bici1Controller : Controller
    {
        private Bici bici1;
        public Bici1Controller(Bici bici1)
        {
            this.bici1 = bici1;
        }

        public IActionResult Index()
        {
            return View(this.bici1);
        }
        [HttpPost]
        public IActionResult index(String accion)
        {
            if (accion == "acelerar")
            {
                this.bici1.Acelerar();
            }
            else
                this.bici1.Frenar();
            return View(this.bici1);
        }
    }
}
