using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Postagem
{
    public class PostagemModel
    {
        public int CdPostagem { get; set; }
        public string Postagem { get; set; }
        public int CdUsuario { get; set; }
        public string Imagem { get; set; }
        public DateTime DhTimestamp { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string NomeUsuario { get; set; }
    }

}
