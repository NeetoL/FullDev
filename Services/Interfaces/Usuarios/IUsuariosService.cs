using Models.Usuarios;

namespace Services.Interfaces.Usuarios
{
    public interface IUsuariosService
    {
        Task<UsuarioResponse> ConsultarUsuarios(int? id = null, string? email = null);
        Task<UsuarioResponse> CadastrarUsuario(UsuariosModel request);
        Task<UsuarioResponse> AtualizarUsuario(UsuariosModel request);
        Task<UsuarioResponse> DeletarUsuario(int id);
    }
}
