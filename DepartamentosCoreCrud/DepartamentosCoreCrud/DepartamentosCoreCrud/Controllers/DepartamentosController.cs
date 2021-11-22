using DepartamentosCoreCrud.Data;
using DepartamentosCoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartamentosCoreCrud.Controllers
{
    public class DepartamentosController : Controller
    {
        DepartamentosContext context;
        public DepartamentosController(DepartamentosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Departamento> listadepartamentos = this.context.GetDepartamentos();
            return View(listadepartamentos);
        }

        public IActionResult Details(int iddepartamento)
        {
            Departamento departamento = this.context.FindDepartamento(iddepartamento);
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(int iddepartamento, String nombre, String localidad)
        {
            int resultado = this.context.InsertDepartamento(iddepartamento, nombre, localidad);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int iddepartamento)
        {
            Departamento depar = this.context.FindDepartamento(iddepartamento);
            return View(depar);
        }
        [HttpPost]
        public IActionResult Edit(int iddepartamento, String nombre, String localidad)
        {
            this.context.UpdateDepartamento(iddepartamento, nombre, localidad);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int iddepartamento)
        {
            this.context.DeleteDepartamento(iddepartamento);
            return RedirectToAction("Index");
        }
    }
}
