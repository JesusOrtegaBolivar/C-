using Microsoft.AspNetCore.Mvc;
using PrimerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerCore.Controllers
{
    public class InformacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InformacionControllerView()
        {
            ViewBag.Nombre = "Jesus";
            ViewBag.Descripcion = "Estoy aprendiendo Net Core";
            ViewBag.Year = 2021;

            return View();
        }
        public IActionResult InformacionControllerViewModel()
        {
            List<Persona> listapersonas = new List<Persona>();
            for(int i = 1; i <= 10; i++)
            {
                Persona person = new Persona();
                person.Nombre = "persona" + i;
                person.Email = "Email" + i;
                person.Edad = 20 + i;
                listapersonas.Add(person);
            }
            return View(listapersonas);
        }
        public IActionResult InformacionGetViewController(String nombre, int edad)
        {
            ViewBag.Nombre = nombre;
            ViewBag.Edad = edad;
            return View();
        }

        public IActionResult InformacionPostViewController()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InformacionPostViewController(Persona persona)
        {
            
            return View(persona);
        }
    }
}
