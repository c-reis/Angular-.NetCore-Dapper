using Dapper;
using Microsoft.Extensions.Configuration;
using projEntrevista.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;


namespace projEntrevista.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IConfiguration _config;

        public PessoaRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public PessoaModels[] GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string sql = "select p.idpessoa, p.nomecompleto, p.idade from pessoa p order by idpessoa";

                connection.Open();

                IEnumerable<PessoaModels> dados = connection.Query<PessoaModels>(sql);

                return dados.ToArray();

            }
        }

        public PessoaModels GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string sql = "select * from pessoa where idpessoa = @pessoaid ";

                connection.Open();

                PessoaModels dados = connection.QueryFirst<PessoaModels>(sql, new { pessoaid = id });

                return dados;

            }
        }

        public void Insert(PessoaModels pessoa)
        {
            using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string sql = "insert into pessoa(nomecompleto, idade, cpf, rua_endereco, num_endereco, bairro_endereco, cidade) " +
                    "values(@nome, @idade, @cpf, @rua, @num, @bairro, @cidade)";

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("nome", pessoa.Nomecompleto);
                parametros.Add("idade", pessoa.Idade);
                parametros.Add("cpf", pessoa.Cpf);
                parametros.Add("rua", pessoa.Rua_endereco);
                parametros.Add("num", pessoa.Num_endereco);
                parametros.Add("bairro", pessoa.Bairro_endereco);
                parametros.Add("cidade", pessoa.Cidade);

                connection.Open();

                connection.Execute(sql, parametros);

            }
        }

        public void Update(int id, PessoaModels pessoa)
        {
            using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {

                string sql = "update pessoa set nomecompleto = @nome, idade = @idade, cpf = @cpf, rua_endereco = @rua, num_endereco = @num, bairro_endereco = @bairro, cidade = @cidade " +
                    "where idpessoa = @pessoaid";

                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("nome", pessoa.Nomecompleto);
                parametros.Add("idade", pessoa.Idade);
                parametros.Add("cpf", pessoa.Cpf);
                parametros.Add("rua", pessoa.Rua_endereco);
                parametros.Add("num", pessoa.Num_endereco);
                parametros.Add("bairro", pessoa.Bairro_endereco);
                parametros.Add("cidade", pessoa.Cidade);
                parametros.Add("pessoaid", id);

                connection.Open();

                connection.Execute(sql, parametros);

            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                string sql = "delete from pessoa where idpessoa = @pessoaid";

                connection.Open();

                connection.Execute(sql, new { pessoaid = id });
            }
        }
    }
}
