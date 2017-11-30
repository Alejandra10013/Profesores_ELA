using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Profesores_ELA.Models;

namespace Profesores_ELA.Controllers
{
    public class HomeController : Controller
    {
        List<Profesor> listado = new List<Profesor>();

        public HomeController()
        {

            listado.Add(new Profesor() { rut = 19270130, nombre = "Karina Alejadnra Cardenas", titulo = "Tecnico Programador", grado ="Tecnico"});
            listado.Add(new Profesor() { rut = 10533932, nombre = "Alfonso Cardenas Mohr", titulo = "Ing Informatica", grado ="Ingeniero"});

        }

        public IActionResult Nuevo()
        {
            return View(new Profesor());
        }

        public IActionResult Listado()
        {
            return View(listado);
        }

       public IActionResult Ficha(int rut, string nombre, string titulo, string grado)
        {
            Profesor nueva = new Profesor()
            {
                rut = rut,
                nombre = nombre,
                titulo = titulo,
                grado = grado
            };

            return View(nueva);
        }
        private Profesor bProfesor(int rut)
        {
            Profesor nueva = new Profesor();
            foreach (Profesor profesor in listado)
            {
                if (profesor.rut == rut)
                {
                    nueva = profesor;
                }
            }
            return nueva;
        }
        public IActionResult Visualizar(int rut)
        {
            Profesor nueva = bProfesor(rut);

            if (nueva != null)
            {
                return View("Ficha", nueva);
            }
            return View("Listado", listado);
        }
    }
}
