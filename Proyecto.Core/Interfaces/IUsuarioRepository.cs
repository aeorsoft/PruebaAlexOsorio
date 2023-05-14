using Proyecto.Core.DTOs;
using Proyecto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Interfaces
{
   public  interface IUsuarioRepository
    {
        Task<List<UsuariolOGIN>> GetUsuario(UsuarioDto usuario);

        Task<IEnumerable<Respuesta>> CreaeUsuario(UsuarioDto usuario);
    }
}
