using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Core.Entities
{
    public class People
    {
        public int Id { get; set; }

        public string nombre { get; set; }

        public string apellidos { get; set; }

        public string identificacion { get; set; }
    }
}

namespace Proyecto.Core
{
    public class IConfiguration
    {
    }
}