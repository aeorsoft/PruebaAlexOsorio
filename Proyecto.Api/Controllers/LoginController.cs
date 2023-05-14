using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Proyecto.Api.Responses;
using Proyecto.Core.DTOs;
using Proyecto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioServices _iusuarioservices;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public LoginController(IConfiguration configuration, IUsuarioServices iusuarioservices, IMapper mapper)
        {
            _configuration = configuration;
            _iusuarioservices = iusuarioservices;
            _mapper = mapper;

        }


        [HttpPost]
        public async Task<IActionResult> LoginUsuario(UsuarioDto usuario)
        {
            var validation = await IsValidUser(usuario);

            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2.First());
                return Ok(new { token });
            }

            return NotFound();


         
        }


        private async Task<(bool, IEnumerable<UsuarioDto>)> IsValidUser(UsuarioDto usuario)
        {
            var usuarios = await _iusuarioservices.GetUsuario(usuario);
            var usuariossDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
            var response = new ApiResponse<IEnumerable<UsuarioDto>>(usuariossDto);
            var isValid = true;
            if(response.Data.Count() == 1)
            {
                isValid = true;
            } else
            {
                isValid = false;
            }

            return (isValid, response.Data);

        }


        private string GenerateToken(UsuarioDto usuario)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim("Usuario", usuario.Email),
                new Claim("Documento", usuario.Cedula),
                new Claim("Nombre", usuario.Nombre),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(15)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        // private 
    }
}
