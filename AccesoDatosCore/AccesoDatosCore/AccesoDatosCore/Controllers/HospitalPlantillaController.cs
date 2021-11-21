using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class HospitalPlantillaController : Controller
    {
        PlantillasContext context;
        public HospitalPlantillaController(PlantillasContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Plantilla> plantilla = new List<Plantilla>();
            plantilla = this.context.GetPlantillaHospital(19);
            return View(plantilla);
        }
    }
}
