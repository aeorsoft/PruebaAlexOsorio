using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto.Core.DTOs
{
    public class UsuarioDto
    {
        public string Nombre { get; set; }

        [NotMapped]
        public string Cedula { get; set; }
        public string Email { get; set; }

      
        public string Password { get; set; }
    }
}
