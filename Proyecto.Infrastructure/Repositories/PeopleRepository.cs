
using Proyecto.Core.Entities;
using Proyecto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Proyecto.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Proyecto.Infrastructure.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PruebaAlexOsorioContext _context;

        public  PeopleRepository(PruebaAlexOsorioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Peoples>> GetPeople()
        
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@Oper", "LISTAR")
                };

                string sql = $"dbo.Sp_People @Oper = @Oper";
                var response = await _context.Peoples.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            } catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }
    }
}
