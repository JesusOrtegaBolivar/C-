﻿using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosSalarioController : Controller
    {
        EmpleadosContext context;
        public EmpleadosSalarioController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int salario)
        {
            List<Empleado> listaempleados = this.context.GetEmpleadosSalario(salario);
            return View(listaempleados);
        }
    }
}
