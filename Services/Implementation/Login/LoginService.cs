using Data.Login;
using Models.Login;
using Models.Usuarios;
using Services.Interfaces.Login;
using Services.Interfaces.Usuarios;
using System.Security.Cryptography;
using System.Text;

namespace Services.Implementation.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginDAL _loginDAL;
        private readonly IUsuarioDAL _usuariosDAL;

        public LoginService(ILoginDAL loginDAL, IUsuarioDAL usuariosDAL)
        {
            _loginDAL = loginDAL;
            _usuariosDAL = usuariosDAL;
        }
        public async Task<LoginResponse> AuthLogin(LoginModel request)
        {
            try
            {
                ValidarCampos(request.email, request.password);

                string senhaCriptografada = CriptografarSenha(request.password);

                var usuario = await _loginDAL.SPC_LOGIN(request.email, senhaCriptografada);

                if (usuario != null)
                {
                    return new LoginResponse
                    {
                        Success = true,
                        Message = "Login realizado com sucesso!",
                        Usuario = usuario
                    };
                }

                return new LoginResponse
                {
                    Success = false,
                    Message = "Usuário ou senha inválidos."
                };
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = $"Erro ao tentar realizar login: {ex.Message}"
                };
            }
        }
        public async Task<LoginResponse> Cadastrar(SignInModel request)
        {
            try
            {
                ValidarCampos(request.email, request.password);

                var usuariosExistentes = await _usuariosDAL.SPC_USUARIOS(null, request.email);

                if (usuariosExistentes.Any())
                    return new LoginResponse
                    {
                        Success = false,
                        Message = "Email já cadastrado."
                    };

                string senhaCriptografada = CriptografarSenha(request.password);

                var novoUsuario = new UsuariosModel
                {
                    email = request.email,
                    password = senhaCriptografada,
                    telefone = request.telefone,
                    endereco = request.endereco,
                    nome = request.nome,
                    sobrenome = request.sobrenome
                };

                var novoId = await _usuariosDAL.SPI_USUARIOS(novoUsuario);

                return new LoginResponse
                {
                    Success = true,
                    Message = $"Usuário {request.nome} {request.sobrenome} cadastrado com sucesso!",
                    Usuario = new UsuariosModel
                    {
                        id = novoId,
                        nome = request.nome,
                        email = request.email
                    }
                };
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = $"Erro ao cadastrar usuário: {ex.Message}"
                };
            }
        }
        public async Task<LoginResponse> EsqueciSenha(LoginModel request)
        {
            try
            {
                ValidarCampos(request.email, request.password);

                string senhaCriptografada = CriptografarSenha(request.password);

                var resultado = await _loginDAL.SPA_ESQUECI_A_SENHA(request.email, senhaCriptografada);

                if (resultado.Contains("sucesso", StringComparison.OrdinalIgnoreCase))
                {
                    return new LoginResponse
                    {
                        Success = true,
                        Message = resultado
                    };
                }

                return new LoginResponse
                {
                    Success = false,
                    Message = resultado
                };
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = $"Erro ao tentar alterar a senha: {ex.Message}"
                };
            }
        }
        private static void ValidarCampos(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(email), "Email e senha são obrigatórios.");
        }
        private static string CriptografarSenha(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }
    }
}
