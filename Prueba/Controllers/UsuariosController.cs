using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [Route("/Nombre")]
    public class UsuariosController : Controller
    {
        //[HttpGet]
        /*public IActionResult Index(String data, int number)
        {
            //ViewData["id"] = data+" "+number;
            String datos = data + " " + number;
            return View("Index", datos);
        }*/

        [Route("/Nombre/Alex")]
        public IActionResult Index(String data, int number)
        {
            //ViewData["id"] = data+" "+number;
            String datos = data + " " + number;
            return View("Index", datos);
        }
    }
}