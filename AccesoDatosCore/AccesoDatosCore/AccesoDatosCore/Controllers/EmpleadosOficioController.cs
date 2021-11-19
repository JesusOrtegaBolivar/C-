using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosOficioController : Controller
    {
        EmpleadosContext context;
        public EmpleadosOficioController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<String> oficios = this.context.GetOficio();
            ViewBag.Oficios = oficios;
            return View();
        }

        [HttpPost]
        public IActionResult Index(String oficio)
        {
            List<Empleado> listaempleados = this.context.GetEmpleadosOficio(oficio);
            List<String> oficios = this.context.GetOficio();
            ViewBag.Oficios = oficios;
            return View(listaempleados);
        }
    }
}
