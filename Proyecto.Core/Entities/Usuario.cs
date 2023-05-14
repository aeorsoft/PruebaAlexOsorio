using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Proyecto.Core.Entities
{
    public partial class Usuario
    {
        public string Nombre { get; set; }

    
        public string Cedula { get; set; }

        
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public partial class UsuariolOGIN
    {
        public string Nombre { get; set; }

        [Key]
        public string Cedula { get; set; }
        public string Email { get; set; }

    }
}
