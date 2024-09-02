using CadastroCliente.App.Interface;
using CadastroCliente.App.Models;
using CadastroCliente.App.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CadastroCliente.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private IUsuarioService _usuarioService;

        public HomeController(ILogger<HomeController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Usuario()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        // Post Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioDataAnnotations usuario)
        {
            if (usuario.usuarioEmail != null && usuario.usuarioSenha != null)
            {
                try
                {
                    var validaLogin = _usuarioService.BuscaUsuarioParaValidação(usuario.usuarioEmail, usuario.usuarioSenha);
                    if (validaLogin != null)
                    {
                        HttpContext.Session.SetString("usuarioLogadoID", "1");//validaLogin.Id.ToString());
                        HttpContext.Session.SetString("nomeUsuarioLogado", "thomas.anjos@hotmail.com");// validaLogin.Email);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        HttpContext.Session.Remove("usuarioLogadoID");
                        HttpContext.Session.Remove("nomeUsuarioLogado");
                        ViewBag.MensagemDeErro = "Email ou senha inválidos!";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.MensagemDeErro = ex.Message;
                }
            }
            return View(usuario);
        }

        // Post Logoff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logoff(Usuario usuario)
        {
            try
            {
                HttpContext.Session.Remove("usuarioLogadoID");
                HttpContext.Session.Remove("nomeUsuarioLogado");
            }

            catch (Exception ex)
            {
                ViewBag.MensagemDeErro = ex.Message;
            }
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}