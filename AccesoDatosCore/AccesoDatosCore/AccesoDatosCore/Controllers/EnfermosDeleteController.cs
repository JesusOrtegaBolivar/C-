using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class EnfermosDeleteController : Controller
    {
        EnfermoContext context;
        public EnfermosDeleteController(EnfermoContext context)
        {
            this.context = context;
        }

        public IActionResult EliminarEnfermosGet(String inscripcion)
        {
            if(inscripcion != null)
            {
                int resultado = this.context.DeleteEnfermos(int.Parse(inscripcion));
            }
            List<Enfermo> listaenfermos = this.context.GetEnfermos();
            return View(listaenfermos);
        }
        public IActionResult EliminarEnfermosFormulario()
        {
            List<Enfermo> listaenfermos = this.context.GetEnfermos();
            return View(listaenfermos);
        }
        [HttpPost]
        public IActionResult EliminarEnfermosFormulario(int inscripcion)
        {
            int eliminados = this.context.DeleteEnfermos(inscripcion);
            List<Enfermo> listaenfermos = this.context.GetEnfermos();
            return View(listaenfermos);
        }


    }
}
