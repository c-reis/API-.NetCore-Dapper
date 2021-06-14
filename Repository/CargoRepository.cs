using APIDapper.Model;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace APIDapper.Repository
{
    public class CargoRepository : ICargoRepository
    { 
        private readonly NpgsqlConnection _connection;

        public CargoRepository(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public IEnumerable<CargoModel> GetCargo()
        {
            _connection.Open();
            var dados = _connection.Query<CargoModel>("select * from cargo");
            _connection.Close();

            return dados;
        }

    }
}
