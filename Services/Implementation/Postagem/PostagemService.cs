using Models.Postagem;
using Services.Interfaces.Postagem;

namespace Services.Implementation.Postagem
{
    public class PostagemService : IPostagemService
    {
        private readonly IPostagemDAL _postagemDAL;

        public PostagemService(IPostagemDAL postagemDAL)
        {
            _postagemDAL = postagemDAL;
        }

        public async Task<PostagemResponse> ConsultarPostagens(int? cd_usuario, string cd_status = "ativo")
        {
            try
            {
                // Chama a DAL para consultar as postagens
                var postagens = await _postagemDAL.SPC_LISTAR_POSTAGENS(cd_usuario, cd_status);

                return new PostagemResponse
                {
                    Success = true,
                    Message = "Postagens consultadas com sucesso!",
                    Postagens = postagens
                };
            }
            catch (Exception ex)
            {
                return new PostagemResponse
                {
                    Success = false,
                    Message = $"Erro ao consultar postagens: {ex.Message}"
                };
            }
        }
    }
}
