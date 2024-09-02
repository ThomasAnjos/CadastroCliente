﻿using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.Application.Controllers
{
    //[UsuarioLogadoFilter]
    public class BaseController : Controller
    {
        protected bool VerificaUsuarioLogado()
        {
            return HttpContext.Session.GetString("usuarioLogadoID") != null;
        }

        // Navbar compartilhada entre controllers filhos
        protected PartialViewResult Navbar()
        {
            bool usuarioLogado = VerificaUsuarioLogado();
            return PartialView("_Navbar", usuarioLogado);
        }
    }
}
