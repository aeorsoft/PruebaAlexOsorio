using Proyecto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Infrastructure.Data
{
    public class PeopleData
    {
        private SqlConnection _conn;

        public PeopleData(string conexion)
        {
            try
            {
                _conn = new SqlConnection(conexion);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public async Task<IEnumerable<People>> listarPeople()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_People", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Oper", "LISTAR");

                cmd.Connection.Open();

                List<People> cls = new List<People>();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (await dr.ReadAsync())
                {
                    People clien = new People
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        nombre = Convert.ToString(dr["nombres"]),
                        apellidos = Convert.ToString(dr["apellidos"]),
                        identificacion = Convert.ToString(dr["identificacion"])
                    };

                    cls.Add(clien);
                }
                dr.Close();

               
                return cls;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
            finally
            {
                _conn.Close();
            }
        }


    }
}
