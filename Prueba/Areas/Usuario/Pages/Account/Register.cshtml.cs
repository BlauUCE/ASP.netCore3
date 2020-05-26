using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace Prueba.Areas.Usuario.Pages.Account
namespace Prueba.Areas.Usuario.Pages.Account
{
    public class RegisterModel : PageModel
    {
        //public string Message { get; set; }

        //public void OnGet(string data)
        public void OnGet()
        {
            //Message = data;
        }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }
    }
}
