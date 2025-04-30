using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models.Usuarios;
using Services.Interfaces.Login;
using System.Data;

namespace Data.Login
{
    public class LoginDAL : ILoginDAL
    {
        private readonly string _connectionString;
        public LoginDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<UsuariosModel?> SPC_LOGIN(string email, string password)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var usuario = await connection.QueryFirstOrDefaultAsync<UsuariosModel>(
                "SPC_LOGIN",
                new { Email = email, Password = password },
                commandType: CommandType.StoredProcedure
            );
            return usuario;
        }
        public async Task<string> SPA_ESQUECI_A_SENHA(string email, string novaSenha)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var resultado = await connection.QueryFirstOrDefaultAsync<string>(
                "SPA_ESQUECI_A_SENHA",
                new { EMAIL = email, NOVA_PASSWORD = novaSenha },
                commandType: CommandType.StoredProcedure
            );

            return resultado ?? "Erro ao tentar alterar a senha.";
        }

    }
}
