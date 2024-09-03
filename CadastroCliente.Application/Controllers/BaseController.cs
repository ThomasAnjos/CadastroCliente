using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Application.Controllers
{
    public class BaseController : Controller
    {
        protected bool VerificaUsuarioLogado()
        {
            return HttpContext.Session.GetString("usuarioLogadoID") != null;
        }

        protected PartialViewResult Navbar()
        {
            bool usuarioLogado = VerificaUsuarioLogado();
            return PartialView("_Navbar", usuarioLogado);
        }
    }
}
