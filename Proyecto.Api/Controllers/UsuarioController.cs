using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Api.Responses;
using Proyecto.Core.DTOs;
using Proyecto.Core.Entities;
using Proyecto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _iusuarioservices;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioServices iusuarioservices, IMapper mapper)
        {
            _iusuarioservices = iusuarioservices;
            _mapper = mapper;

        }

        /// <summary>
        /// Metodo que sirve para registrar los usuarios
        /// </summary>
        /// <param name="usuario">Registro de Usuario</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreaeUsuario(UsuarioDto usuario)
        {
            var usuarios = await _iusuarioservices.CreaeUsuario(usuario);
            var usuariossDto = _mapper.Map<IEnumerable<Respuesta>>(usuarios);
            var response = new ApiResponse<IEnumerable<Respuesta>>(usuariossDto);

            return Ok(response);
        }
    }
}
