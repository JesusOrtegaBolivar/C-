using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Models;
using AccesoDatosCore.Data;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosController : Controller
    {
        EmpleadosContext context;
        public EmpleadosController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Empleado> listaempleados = this.context.GetEmpleados();
            return View(listaempleados);
        }
    }
}
