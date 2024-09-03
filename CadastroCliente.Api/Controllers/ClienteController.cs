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

        [Route("Api/AdicionaCliente")]
        [HttpPost]
        public async Task<IActionResult> AdicionaCliente([FromBody] Cliente cliente)
        {
            await _clienteService.Adicionar(cliente);
            return Ok();

        }

        [HttpGet]
        [Route("Api/BuscaTodosClientes")]
        public async Task<IActionResult> BuscaTodosClientes()
        {
            var result = await _clienteService.ListaTodos();
            return Ok(result);

        }

        [HttpGet]
        [Route("Api/BuscaClientePorId/{Id?}")]
        public async Task<IActionResult> BuscaClientePorId(int Id)
        {
            var result = await _clienteService.LeituraPorId(Id);
            return Ok(result);

        }

        [HttpPut]
        [Route("Api/AlteraClientes")]
        public async Task<IActionResult> AlteraCliente([FromBody] Cliente usuario)
        {
            var result = await _clienteService.Alterar(usuario);
            return Ok(result);

        }

        [HttpDelete]
        [Route("Api/ApagarCliente/{Id?}")]
        public async Task<IActionResult> ApagarCliente(int Id)
        {
            var result = await _clienteService.Apagar(Id);
            return Ok(result);

        }
    }
}