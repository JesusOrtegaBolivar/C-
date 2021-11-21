using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class HospitalController : Controller
    {
        HospitalesContext context;
        public HospitalController(HospitalesContext context)
        {
            this.context = context;
        }
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Provincial()
        {
            List<Hospital> hospital = new List<Hospital>();
            hospital = this.context.GetHospital("Provincial");
            return View(hospital);
        }
        public IActionResult General()
        {
            List<Hospital> hospital = new List<Hospital>();
            hospital = this.context.GetHospital("General");
            return View(hospital);
        }
        public IActionResult Lapaz()
        {
            List<Hospital> hospital = new List<Hospital>();
            hospital = this.context.GetHospital("La Paz");
            return View(hospital);
        }
        public IActionResult Sancarlos()
        {
            List<Hospital> hospital = new List<Hospital>();
            hospital = this.context.GetHospital("San Carlos");
            return View(hospital);
        }
        public IActionResult Ruber()
        {
            List<Hospital> hospital = new List<Hospital>();
            hospital = this.context.GetHospital("General");
            return View(hospital);
        }
    }
}
