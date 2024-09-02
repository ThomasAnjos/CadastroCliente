using Core.Entitites;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("AdicionaUsuario")]
        public async Task<IActionResult> AdicionaUsuario([FromBody]Usuario usuario)
        {
            await _usuarioService.Adicionar(usuario);
            return Ok();

        }

        [HttpGet]
        [Route("BuscaTodosUsuarios")]
        public async Task<IActionResult> BuscaTodosUsuarios()
        {
            var result = await _usuarioService.ListaTodos();
            return Ok(result);

        }

        [HttpGet]
        [Route("BuscaUsuarioPorId/{Id?}")]
        public async Task<IActionResult> BuscaUsuarioPorId(int Id)
        {
            var result = await _usuarioService.LeituraPorId(Id);
            return Ok(result);

        }

        [HttpPut]
        [Route("AlteraUsuario")]
        public async Task<IActionResult> AlteraUsuario([FromBody] Usuario usuario)
        {
            var result = await _usuarioService.Alterar(usuario);
            return Ok(result);

        }

        [HttpDelete]
        [Route("ApagarUsuario/{Id?}")]
        public async Task<IActionResult> ApagarUsuario(int Id)
        {
            var result = await _usuarioService.Apagar(Id);
            return Ok(result);

        }
    }
}
