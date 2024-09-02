using Dapper;
using Infrastructure.Dto;
using Infrastructure.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration configuration;
        public UsuarioRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> Adicionar(UsuarioDto entity)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UsuarioNome", entity.UsuarioNome);
                parameters.Add("UsuarioEmail", entity.UsuarioEmail);
                parameters.Add("UsuarioSenha", entity.UsuarioSenha);
                var result = await connection.ExecuteAsync("InsereUsuario", parameters, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<int> Alterar(UsuarioDto entity)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UsuarioNome", entity.UsuarioNome);
                parameters.Add("UsuarioEmail", entity.UsuarioEmail);
                parameters.Add("UsuarioSenha", entity.UsuarioSenha);
                parameters.Add("UsuarioId", entity.UsuarioId);
                var result = await connection.ExecuteAsync("AlteraUsuario", parameters, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<int> Apagar(int Id)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UsuarioId", Id);
                var result = await connection.ExecuteAsync("ApagaUsuario", parameters, commandType: System.Data.CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<UsuarioDto> LeituraPorId(int Id)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UsuarioId", Id);
                UsuarioDto Usuario = await connection.QueryFirstOrDefaultAsync<UsuarioDto>("BuscaUsuariosPorId", parameters, commandType: System.Data.CommandType.StoredProcedure);

                return Usuario;
            }
        }

        public async Task<List<UsuarioDto>> ListaTodos()
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var listUsuarios = await connection.QueryAsync<UsuarioDto>("BuscaTodosUsuarios", commandType: CommandType.StoredProcedure);

                return listUsuarios.ToList();
            }

        }
    }
}
