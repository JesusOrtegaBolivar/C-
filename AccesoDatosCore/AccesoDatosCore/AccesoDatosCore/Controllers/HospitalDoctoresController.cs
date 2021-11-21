using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class HospitalDoctoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
