using CadastroCliente.App.Models;

namespace CadastroCliente.App.Interface
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> BuscaListaCompletaUsuario();

        Task InsereDadosUsuario(Usuario usuario);

        Task AlteraDadosUsuario(Usuario usuario);

        Task RemoveDadosUsuario(int id);

        Task<Usuario> BuscaUsuarioPorId(int id); 

        Task<Usuario> BuscaUsuarioParaValidação(string email, string senha);
    }
}
