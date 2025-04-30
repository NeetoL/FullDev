using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models.Usuarios;
using Services.Interfaces.Usuarios;
using System.Data;

namespace Services.Implementation.Postagem;
public class UsuariosDAL : IUsuarioDAL
{
    private readonly string _connectionString;

    public UsuariosDAL(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<List<UsuariosModel>> SPC_USUARIOS(int? usuarioId = null, string? email = null)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var usuarios = await connection.QueryAsync<UsuariosModel>(
            "SPC_USUARIOS",
            new { Id = usuarioId, Email = email },
            commandType: CommandType.StoredProcedure
        );
        return usuarios.ToList();
    }
    public async Task<int> SPI_USUARIOS(UsuariosModel usuario)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var novoId = await connection.ExecuteScalarAsync<int>(
            "SPI_USUARIOS",
            new
            {
                Email = usuario.email,
                Password = usuario.password,
                Telefone = usuario.telefone,
                Endereco = usuario.endereco,
                Nome = usuario.nome,
                Sobrenome = usuario.sobrenome
            },
            commandType: CommandType.StoredProcedure
        );
        return novoId;
    }
    public async Task<int> SPA_USUARIOS(UsuariosModel usuario)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var linhasAfetadas = await connection.ExecuteAsync(
            "SPA_USUARIOS",
            new
            {
                Id = usuario.id,
                Email = usuario.email,
                Password = usuario.password,
                Telefone = usuario.telefone,
                Endereco = usuario.endereco,
                Nome = usuario.nome,
                Sobrenome = usuario.sobrenome
            },
            commandType: CommandType.StoredProcedure
        );
        return linhasAfetadas;
    }
    public async Task<int> SPD_USUARIOS(int usuarioId)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var linhasAfetadas = await connection.ExecuteAsync(
            "SPD_USUARIOS",
            new { Id = usuarioId },
            commandType: CommandType.StoredProcedure
        );
        return linhasAfetadas;
    }
}