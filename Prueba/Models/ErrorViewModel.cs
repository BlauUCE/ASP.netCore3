using System;

namespace Prueba.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        //propiedad aumentada
        public string ErrorMessage { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
