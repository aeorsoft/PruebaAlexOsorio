using Proyecto.Core.DTOs;
using Proyecto.Core.Entities;
using Proyecto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Task<IEnumerable<Respuesta>> CreaeUsuario(UsuarioDto usuario)
        {
            var usuarios = _usuarioRepository.CreaeUsuario(usuario);
            return usuarios;
        }

        public Task<List<UsuariolOGIN>> GetUsuario(UsuarioDto usuario)
        {
            var usuarios = _usuarioRepository.GetUsuario(usuario);
            return usuarios;
        }
    }
}
