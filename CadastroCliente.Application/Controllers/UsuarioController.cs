using CadastroCliente.Application.Interface;
using CadastroCliente.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Application.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Usuario()
        {
            return View(await _usuarioService.BuscaListaCompletaUsuario());
        }


        public IActionResult UsuarioCriar()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsuarioCriar(ApplicationUsuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _usuarioService.InsereDadosUsuario(usuario);

            return RedirectToAction("Usuario");
        }
        public IActionResult UsuarioAlterar(int Id)
        {
            ApplicationUsuario usuario = new ApplicationUsuario();

            usuario = _usuarioService.BuscaUsuarioPorId(Id).Result;

            _usuarioService.AlteraDadosUsuario(usuario);

            return RedirectToAction("Usuario");
        } 

        public async Task<IActionResult> Index(string Email, string Senha)
        {
            return View(await _usuarioService.BuscaUsuarioParaValidacao(Email, Senha));
        }

        public IActionResult ApagarUsuario(int Id)
        {
            _usuarioService.RemoveDadosUsuario(Id);

            return RedirectToAction("Usuario");
        }
    }
}
