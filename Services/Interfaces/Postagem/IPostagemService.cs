using Models.Postagem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.Postagem
{
    public interface IPostagemService
    {
        Task<PostagemResponse> ConsultarPostagens(int? cd_usuario, string cd_status = "ativo");
    }
}
