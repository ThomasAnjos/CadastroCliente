using Dapper;
using Infrastructure.Dto;
using Infrastructure.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration configuration;
        public ClienteRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> Adicionar(ClienteDto entity)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ClienteNome", entity.ClienteNome);
                parameters.Add("ClienteEmail", entity.ClienteEmail);
                parameters.Add("ClienteLogotipo", entity.ClienteLogotipo);
                var result = connection.Query<int>("InsereCliente", parameters).Single();  //await connection.ExecuteScalar("InsereCliente", parameters, commandType: System.Data.CommandType.StoredProcedure);

                DynamicParameters parametersLogradouro = new DynamicParameters();
                parametersLogradouro.Add("ClienteLogradouro", entity.ClienteLogradouro);
                parametersLogradouro.Add("ClienteId", result);
                await connection.ExecuteAsync("InsereLogradouro", parametersLogradouro, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<int> Alterar(ClienteDto entity)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ClienteNome", entity.ClienteNome);
                parameters.Add("ClienteEmail", entity.ClienteEmail);
                parameters.Add("ClienteLogradouro", entity.ClienteLogradouro);
                parameters.Add("ClienteLogotipo", entity.ClienteLogotipo);
                parameters.Add("ClienteId", entity.ClienteId);

                var result = await connection.ExecuteAsync("AlteraCliente", parameters, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<int> Apagar(int Id)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ClienteId", Id);
                var result = await connection.ExecuteAsync("ApagaCliente", parameters, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<ClienteDto> LeituraPorId(int Id)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ClienteId", Id);
                ClienteDto cliente = await connection.QueryFirstOrDefaultAsync<ClienteDto>("BuscaClientesPorId", parameters, commandType: System.Data.CommandType.StoredProcedure);

                return cliente;
            }
        }

        public async Task<List<ClienteDto>> ListaTodos()
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var lisClientes = await connection.QueryAsync<ClienteDto>("BuscaTodosClientes", commandType: CommandType.StoredProcedure);

                return lisClientes.ToList();
            }
        }
    }
}
