using Models.Usuarios;

namespace Services.Interfaces.Usuarios
{
    public interface IUsuarioDAL
    {
        Task<List<UsuariosModel>> SPC_USUARIOS(int? usuarioId = null, string? email = null);
        Task<int> SPI_USUARIOS(UsuariosModel usuario);
        Task<int> SPA_USUARIOS(UsuariosModel usuario);
        Task<int> SPD_USUARIOS(int usuarioId);
    }
}
