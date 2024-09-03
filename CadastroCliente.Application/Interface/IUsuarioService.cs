using CadastroCliente.Application.Models;

namespace CadastroCliente.Application.Interface
{
    public interface IUsuarioService
    {
        Task<List<ApplicationUsuario>> BuscaListaCompletaUsuario();

        Task<Uri> InsereDadosUsuario(ApplicationUsuario usuario);

        Task<Uri> AlteraDadosUsuario(ApplicationUsuario usuario);

        Task<Uri> RemoveDadosUsuario(int id);

        Task<ApplicationUsuario> BuscaUsuarioPorId(int id);

        Task<ApplicationUsuario> BuscaUsuarioParaValidacao(string email, string senha);
    }
}
