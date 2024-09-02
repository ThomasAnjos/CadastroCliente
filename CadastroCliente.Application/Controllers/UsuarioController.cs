using CadastroCliente.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Application.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public IActionResult Usuario()
        {
            return View();
        }

        public IActionResult UsuarioCriar()
        {
            return View();
        }

        public IActionResult UsuarioAlterar()
        { 
            return View();
        }

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index(string Email, string Senha)
        {
            return View(await _usuarioService.BuscaUsuarioParaValidação(Email, Senha));
        }
    }
}
