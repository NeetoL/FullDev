using Models.Postagem;

namespace Services.Interfaces.Postagem
{
    public interface IPostagemDAL
    {
        Task<IEnumerable<PostagemModel>> SPC_LISTAR_POSTAGENS(int? cdUsuario, string status);
    }
}
