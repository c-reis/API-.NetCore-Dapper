using APIDapper.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDapper.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly NpgsqlConnection _connection;

        public PessoaRepository(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public IEnumerable<PessoaModel> GetPessoa()
        {
            _connection.Open();

            IEnumerable<PessoaModel> date = _connection.Query<PessoaModel>("select * from pessoa order by pessoaId");

            _connection.Close();

            return date;
        }

        public IEnumerable<PessoaModel> GetPessoasById(int idpessoa)
        {
            string sql = "select p.nome, p.idade, c.descricao from pessoa p inner join cargo c on p.cargoid = c.cargoid where p.pessoaId = @valorid";
            _connection.Open();
            IEnumerable<PessoaModel> retorno = _connection.Query<PessoaModel, CargoModel, PessoaModel>(sql, (pessoa, c) =>
                                                               {
                                                                   pessoa.cargo = c;
                                                                   return pessoa;
                                                               }, new { valorid = idpessoa}, 
                                                               splitOn: "nome,descricao");
                                                               

            _connection.Close();

            return retorno;
        }

        public int GetPessoaId()
        {
            string query = "select max(p.pessoaid) from pessoa p";
            _connection.Open();
            int dados = _connection.Query<int>(query).First();
            _connection.Close();

            return dados;
        }

        public bool SetPessoa(PessoaModel valores)
        {
            _connection.Open();
            string query = "insert into pessoa values(@pessoaid, @nome, @idade, @cargoid)";
            _connection.Execute(query, new { 
                valores.pessoaId,
                valores.nome,
                valores.idade,
                valores.cargoid
            });

            _connection.Close();

            return true;

        }
    }
}
