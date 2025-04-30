using Microsoft.AspNetCore.Mvc;
using Models.Login;
using Services.Interfaces.Login;

namespace FullDevAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class LoginController(ILoginService loginService) : ControllerBase
    {
        private readonly ILoginService _loginService = loginService;

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] LoginModel request) =>
            Ok(new { mensagem = _loginService.AuthLogin(request) });

        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] SignInModel request) =>
            Ok(new { mensagem = _loginService.Cadastrar(request) });

        [HttpPut("esqueci-senha")]
        public IActionResult EsqueciSenha([FromBody] LoginModel request) =>
            Ok(new { mensagem = _loginService.EsqueciSenha(request) });
    }
}
