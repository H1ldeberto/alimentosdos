using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;
using Dapper;
using Models.Interfaces;
using System.Web.Http;

namespace Datos
{
    public class Datos: IDatos
    {
        private readonly IConfiguration _configuration;

        private readonly string cadenaConexion;
        public Datos(IConfiguration configuration)
        {

            _configuration = configuration;
            cadenaConexion = _configuration.GetConnectionString("CadenaSQLAlimentos");
            
        }

      
        /// ////////////////////////////////////////////////
       
        public async Task<List<Alimento>> GetAll()
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                var result = connection.Query<Alimento>("ListaAlimentos", commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<Ingrediente>> GetIngredientes(int id)
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@id", id);

                var result = connection.Query<Ingrediente>("ListaIngredientes", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
                
                return result.ToList();
            }
        }

        public async Task<bool> DeleteAlimentos(int id)
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@id", id);

                var result = await connection.ExecuteAsync("BorraAlimentos", queryParameters, commandType: System.Data.CommandType.StoredProcedure);

                return result == 1;
            }
        }



        public async Task<int> AgregarAlimentos(Alimento request)
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@NombreAlimento", request.NombreAlimentos);
                queryParameters.Add("@Precio", request.Precio);

                var result = await connection.ExecuteScalarAsync("AgregaAlimento", queryParameters, commandType: System.Data.CommandType.StoredProcedure);

                return Convert.ToInt32(result);
            }
        }

        public async Task<int> AgregarIngredientes(Ingrediente request)
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@NombreIngrediente", request.NombreIngrediente);
                queryParameters.Add("@idAlimentos", request.Idalimentos);

                var result = await connection.ExecuteScalarAsync("AgregaIngrediente", queryParameters, commandType: System.Data.CommandType.StoredProcedure);

                return Convert.ToInt32(result);
            }
        }

    }
}

