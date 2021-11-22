using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class HospitalDoctoresController : Controller
    {
        DoctoresContext context;
        public HospitalDoctoresController(DoctoresContext context)
        {
            this.context = context;
        }

        public IActionResult Index(String code)
        {
            int codigo = int.Parse(code);
            List<Doctor> doctores = new List<Doctor>();
            doctores = this.context.GetDoctoresHospital(codigo);
            return View(doctores);
        }
    }
}
