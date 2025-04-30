using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models.Postagem;
using System.Data;
using Dapper;
using Services.Interfaces.Postagem;

namespace Services.Implementation.Postagem;
public class PostagemDAL : IPostagemDAL
{
    private readonly string _connectionString;

    public PostagemDAL(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<IEnumerable<PostagemModel>> SPC_LISTAR_POSTAGENS(int? cdUsuario, string status)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var parametros = new
        {
            CdUsuario = cdUsuario,
            Status = status
        };

        var postagens = await connection.QueryAsync<PostagemModel>(
            "SPC_LISTAR_POSTAGENS",
            parametros,
            commandType: CommandType.StoredProcedure
        );

        return postagens;
    }
}
