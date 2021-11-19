using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class MaestroDetalleEmpleadosController : Controller
    {

        EmpleadosContext context;
        public MaestroDetalleEmpleadosController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult DatosEmpleados()
        {
            List<Empleado> listaempleado = this.context.GetEmpleados();
            return View(listaempleado);
        }
        public IActionResult DetallesEmpleados(int idempleado)
        {
            Empleado emp = this.context.BuscarEmpleado(idempleado);
            return View(emp);
        }
    }
}
