using Models.Login;

namespace Services.Interfaces.Login;
public interface ILoginService
{
    Task<LoginResponse> AuthLogin(LoginModel request);
    Task<LoginResponse> Cadastrar(SignInModel request);
    Task<LoginResponse> EsqueciSenha(LoginModel request);
}