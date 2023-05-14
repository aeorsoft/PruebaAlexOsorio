using Microsoft.EntityFrameworkCore;
using Proyecto.Core.DTOs;
using Proyecto.Core.Entities;
using Proyecto.Core.Interfaces;
using Proyecto.Infrastructure.Data;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Core.Exceptions;

namespace Proyecto.Infrastructure.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly PruebaAlexOsorioContext _context;

        public UsuarioRepository(PruebaAlexOsorioContext context)
        {
            _context = context;
        }

        public async Task<List<UsuariolOGIN>> GetUsuario(UsuarioDto usuario)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@Oper", "LOGIN"),
                    new SqlParameter("@password", usuario.Password),
                    new SqlParameter("@email", usuario.Email)
                };

                string sql = $"dbo.Sp_Usuario @Oper = @Oper, @email = @email,  @password = @password";
                var response = await _context.UsuarioLogin.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> CreaeUsuario(UsuarioDto usuario)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@Oper", "CREAR"),
                    new SqlParameter("@nombre", usuario.Nombre),
                    new SqlParameter("@cedula", usuario.Cedula),
                    new SqlParameter("@password", usuario.Password),
                    new SqlParameter("@email", usuario.Email)
                };

                string sql = $"dbo.Sp_Usuario @Oper = @Oper, @password = @password, @email = @email, @nombre = @nombre, @cedula = @cedula";
                IEnumerable<Respuesta> response = await _context.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                //throw new BusinessException($"Error: {ex.Message}");
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

     
    }
}
