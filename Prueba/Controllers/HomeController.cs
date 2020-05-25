using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prueba.Models;

namespace Prueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ejemplo lanzar excepcion
            //throw new Exception("Alguna excepcion");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //agregando parametro int que puede secibir datos nulos Error(int? statusCode)
        public IActionResult Error(int? statusCode = null)
        {
            ErrorViewModel error = null;
            if (statusCode != null)
            {
                error = new ErrorViewModel
                {
                    RequestId = Convert.ToString(statusCode),
                    //aumento
                    ErrorMessage = "Error al procesar la solicitud"
                };
            } 
            else
            {
                var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                if(exceptionFeature != null)
                {
                    error = new ErrorViewModel
                    {
                        RequestId = "500",
                        ErrorMessage = exceptionFeature.Error.Message
                    };
                }
            } 

            return View(error);
            //original
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
