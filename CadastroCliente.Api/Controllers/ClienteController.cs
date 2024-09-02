using Core.Entitites;
using Core.Interfaces;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [Route("AdicionaCliente")]
        public async Task<IActionResult> AdicionaCliente([FromBody] Cliente cliente)
        {
            await _clienteService.Adicionar(cliente);
            return Ok();

        }

        [HttpGet]
        [Route("BuscaTodosClientes")]
        public async Task<IActionResult> BuscaTodosClientes()
        {
            var result = await _clienteService.ListaTodos();
            return Ok(result);

        }

        [HttpGet]
        [Route("BuscaClientePorId/{Id?}")]
        public async Task<IActionResult> BuscaClientePorId(int Id)
        {
            var result = await _clienteService.LeituraPorId(Id);
            return Ok(result);

        }

        [HttpPut]
        [Route("AlteraCliente")]
        public async Task<IActionResult> AlteraCliente([FromBody] Cliente usuario)
        {
            var result = await _clienteService.Alterar(usuario);
            return Ok(result);

        }

        [HttpDelete]
        [Route("ApagarCliente/{Id?}")]
        public async Task<IActionResult> ApagarCliente(int Id)
        {
            var result = await _clienteService.Apagar(Id);
            return Ok(result);

        }
    }
}