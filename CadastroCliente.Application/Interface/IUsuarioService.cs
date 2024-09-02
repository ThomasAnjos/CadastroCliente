using CadastroCliente.Application.Models;

namespace CadastroCliente.Application.Interface
{
    public interface IUsuarioService
    {
        Task<List<ApplicationUsuario>> BuscaListaCompletaUsuario();

        Task InsereDadosUsuario(ApplicationUsuario usuario);

        Task AlteraDadosUsuario(ApplicationUsuario usuario);

        Task RemoveDadosUsuario(int id);

        Task<ApplicationUsuario> BuscaUsuarioPorId(int id);

        Task<ApplicationUsuario> BuscaUsuarioParaValidação(string email, string senha);
    }
}
