using Microsoft.AspNetCore.Mvc;
using Models.Usuarios;
using Services.Interfaces.Usuarios;

namespace FullDevAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // Definição da rota de acesso do controlador
    public class UsuariosController : ControllerBase  // Corrigido a herança da classe
    {
        private readonly IUsuariosService _usuariosService;

        // Injeção de dependência via construtor
        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpGet]  // Endpoint GET para consultar usuários
        public async Task<IActionResult> ConsultarUsuarios([FromQuery] int? id = null, [FromQuery] string? email = null)
        {
            var response = await _usuariosService.ConsultarUsuarios(id, email);
            return Ok(response);
        }

        [HttpPost]  // Endpoint POST para cadastrar um novo usuário
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuariosModel usuario)
        {
            var response = await _usuariosService.CadastrarUsuario(usuario);
            return Ok(response);
        }

        [HttpPut]  // Endpoint PUT para atualizar um usuário
        public async Task<IActionResult> AtualizarUsuario([FromBody] UsuariosModel usuario)
        {
            var response = await _usuariosService.AtualizarUsuario(usuario);
            return Ok(response);
        }

        [HttpDelete("{id}")]  // Endpoint DELETE para deletar um usuário
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            var response = await _usuariosService.DeletarUsuario(id);
            return Ok(response);
        }
    }
}
