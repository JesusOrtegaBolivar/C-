using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class PlantillasController : Controller
    {
        PlantillasContext context;
        public PlantillasController(PlantillasContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Plantilla> datosplantillas = this.context.GetPlantillas();
            return View(datosplantillas);
        }
    }
}
