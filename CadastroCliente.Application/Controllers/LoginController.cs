using CadastroCliente.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Session;

namespace CadastroCliente.Application.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        [Route("Api/Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginCliente(ApplicationLogin model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "admin" && model.Password == "admin")
                { 

                    return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    ModelState.AddModelError("", "Nome de usuário ou senha inválidos.");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
