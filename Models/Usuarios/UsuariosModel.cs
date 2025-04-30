using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Usuarios
{
    public class UsuariosModel
    {
        public int id { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? telefone { get; set; }
        public string? endereco { get; set; }
        public string? nome { get; set; }
        public string? sobrenome { get; set; }
    }
}
