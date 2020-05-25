using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    
    
    //[Route("[controller]/[action]")]  //de ley pasar en la url controlador y action 
    //[Route("/Nombre")]  //cambiar nombre de controlador
    public class UsuariosController : Controller
    {
        //[HttpGet]
        /*public IActionResult Index(String data, int number)
        {
            //ViewData["id"] = data+" "+number;
            String datos = data + " " + number;
            return View("Index", datos);
        }*/

        //[Route("/Nombre/uno")]
        //[Route("/Nombre/otro/{data?}")]
        //[Route("/[controller]/[action]/{data?}")]
        //[HttpGet("/[controller]/[action]/{data?}")]
        /*public IActionResult Index(String data, int number)
        {
            //ViewData["id"] = data+" "+number;
            String datos = data + " " + number;
            return View("Index", datos);
        }*/

        //[HttpGet("/[controller]/[action]/{data=int?}")]  //no funciona no puede ser opcional si hay tipo
        //[HttpGet("/[controller]/[action]/{data=double}")]
        //public IActionResult Index(double data)
        //{
        //    return View("Index", data);
        //}

        //[HttpGet("/[controller]/[action]/{data=int}")]
        //public IActionResult Index(int data)
        //{
        //    return View("Index", data);
        //}
        //default
        //public IActionResult Index()
        //{ 
        //    return View();
        //}

        public IActionResult Index()
        {
            //var url = Url.Action("Metodo", "Usuarios", new { age=25, nombre="Juan" });
            //return Content(url);

            var url = Url.RouteUrl("nombre", new { age = 25, nombre = "Juan" });
            return Redirect(url);
        }


        [HttpGet("/[controller]/[action]/{data=double}", Name = "nombre")] //asignar nombre a las rutas
        public IActionResult Metodo(int age, string nombre)
        {
            var x = $"nombre {nombre} edad {age}";
            return View("Index", x);
        }
    }
}