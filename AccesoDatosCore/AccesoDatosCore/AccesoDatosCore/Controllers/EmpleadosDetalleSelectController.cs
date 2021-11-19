using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosDetalleSelectController : Controller
    {
        EmpleadosContext context;
        public EmpleadosDetalleSelectController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Empleado> listaEmpleados = this.context.GetEmpleados();
            ViewBag.lista = listaEmpleados;
            return View();
        }
        [HttpPost]
        public IActionResult Index (int idempleado)
        {
            List<Empleado> listaEmpleados = this.context.GetEmpleados();
            ViewBag.lista = listaEmpleados;
            Empleado emp = this.context.BuscarEmpleado(idempleado);
            return View(emp);
        }
    }
}
