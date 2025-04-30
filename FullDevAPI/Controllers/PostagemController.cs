using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Postagem;
using Models.Postagem;

namespace FullDevAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemService _postagemService;

        public PostagemController(IPostagemService postagemService)
        {
            _postagemService = postagemService;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarPostagens([FromQuery] int? cdUsuario, [FromQuery] string status = "ativo")
        {
            var response = await _postagemService.ConsultarPostagens(cdUsuario, status);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
