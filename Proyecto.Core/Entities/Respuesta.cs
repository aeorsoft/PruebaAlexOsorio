using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto.Core.Entities
{
    public class Respuesta
    { 
        public string mensaje { get; set; }

        [Key]
        public string identificador { get; set; }
        public string estado { get; set; }
    }
}
