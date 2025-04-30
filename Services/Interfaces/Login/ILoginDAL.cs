using Models.Usuarios;

namespace Services.Interfaces.Login
{
    public interface ILoginDAL
    {
        Task<UsuariosModel?> SPC_LOGIN(string email, string password);
        Task<string> SPA_ESQUECI_A_SENHA(string email, string novaSenha);
    }
}
