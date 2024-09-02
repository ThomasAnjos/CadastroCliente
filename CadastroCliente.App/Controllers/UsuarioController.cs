using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.App.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        //public async Task<IActionResult> Index(string Email, string Senha)
        //{
        //    return View(await _usuarioService.BuscaUsuarioParaValidação(Email, Senha));
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var data = await unitOfWork.Products.GetAllAsync();
        //    return Ok(data);
        //}

    }
}
