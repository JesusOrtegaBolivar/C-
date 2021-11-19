using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class IncrementoPlantillaFunciones : Controller
    {
        PlantillasContext context;
        public IncrementoPlantillaFunciones(PlantillasContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<String> listafunciones = this.context.GetFunciones();
            ViewBag.Funciones = listafunciones;
            return View();
        }

        [HttpPost]
        public IActionResult Index (String funcion, int incremento)
        {
            List<String> listafunciones = this.context.GetFunciones();
            ViewBag.Funciones = listafunciones;
            int modificados = this.context.UpdatePlantillaFuncion(funcion, incremento);
            List<Plantilla> listaplantilla = this.context.GetPlantillaFunciones(funcion);
            return View(listaplantilla);
        }
    }
}
