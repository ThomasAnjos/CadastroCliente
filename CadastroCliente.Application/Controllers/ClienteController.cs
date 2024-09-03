using CadastroCliente.Application.Interface;
using CadastroCliente.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Application.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Cliente()
        {
            return View(await _clienteService.BuscaListaCompletaCliente());
        }

        public IActionResult ClienteCriar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClienteCriar(ApplicationCliente Cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _clienteService.InsereDadosCliente(Cliente);

            return RedirectToAction("Cliente");
        }

        public IActionResult ClienteAlterar(int Id)
        {
            ApplicationCliente Cliente = new ApplicationCliente();

            Cliente = _clienteService.BuscaClientePorId(Id).Result;

            _clienteService.AlteraDadosCliente(Cliente);

            return RedirectToAction("Cliente");
        }

        public async Task<IActionResult> Index(string Email, string Senha)
        {
            return View(await _clienteService.BuscaClienteParaValidacao(Email, Senha));
        }

        public IActionResult ApagarCliente(int Id)
        {
            _clienteService.RemoveDadosCliente(Id);

            return RedirectToAction("Cliente");
        }
    }
}
