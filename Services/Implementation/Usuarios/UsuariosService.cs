using Models.Usuarios;
using Services.Interfaces.Usuarios;

namespace Services.Implementation.Usuarios
{
    public class UsuariosService(IUsuarioDAL usuariosDAL) : IUsuariosService
    {
        private readonly IUsuarioDAL _usuariosDAL = usuariosDAL;

        public async Task<UsuarioResponse> ConsultarUsuarios(int? id = null, string? email = null)
        {
            try
            {
                var usuarios = await _usuariosDAL.SPC_USUARIOS(id, email);

                return new UsuarioResponse
                {
                    Success = true,
                    Message = "Usuário(s) consultado(s) com sucesso!",
                    Usuarios = usuarios
                };
            }
            catch (Exception ex)
            {
                return new UsuarioResponse
                {
                    Success = false,
                    Message = $"Erro ao consultar usuários: {ex.Message}"
                };
            }
        }
        public async Task<UsuarioResponse> CadastrarUsuario(UsuariosModel request)
        {
            try
            {
                // Criptografar a senha
                request.password = CriptografarSenha(request.password);

                var novoId = await _usuariosDAL.SPI_USUARIOS(request);

                return new UsuarioResponse
                {
                    Success = true,
                    Message = $"Usuário {request.nome} {request.sobrenome} cadastrado com sucesso!",
                    Usuario = new UsuariosModel
                    {
                        id = novoId,
                        email = request.email,
                        nome = request.nome,
                        sobrenome = request.sobrenome
                    }
                };
            }
            catch (Exception ex)
            {
                return new UsuarioResponse
                {
                    Success = false,
                    Message = $"Erro ao cadastrar usuário: {ex.Message}"
                };
            }
        }
        public async Task<UsuarioResponse> AtualizarUsuario(UsuariosModel request)
        {
            try
            {
                if (request.id == 0)
                    throw new ArgumentException("ID do usuário obrigatório para atualização.");

                if (!string.IsNullOrEmpty(request.password))
                {
                    request.password = CriptografarSenha(request.password);
                }

                await _usuariosDAL.SPA_USUARIOS(request);

                return new UsuarioResponse
                {
                    Success = true,
                    Message = $"Usuário {request.nome} atualizado com sucesso!"
                };
            }
            catch (Exception ex)
            {
                return new UsuarioResponse
                {
                    Success = false,
                    Message = $"Erro ao atualizar usuário: {ex.Message}"
                };
            }
        }
        public async Task<UsuarioResponse> DeletarUsuario(int id)
        {
            try
            {
                await _usuariosDAL.SPD_USUARIOS(id);

                return new UsuarioResponse
                {
                    Success = true,
                    Message = $"Usuário ID {id} deletado com sucesso!"
                };
            }
            catch (Exception ex)
            {
                return new UsuarioResponse
                {
                    Success = false,
                    Message = $"Erro ao deletar usuário: {ex.Message}"
                };
            }
        }
        private static string CriptografarSenha(string senha)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(senha);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }
    }
}
