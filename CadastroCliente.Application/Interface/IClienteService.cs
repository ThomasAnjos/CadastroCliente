using CadastroCliente.Application.Models;

namespace CadastroCliente.Application.Interface
{
    public interface IClienteService
    {
        Task<List<ApplicationCliente>> BuscaListaCompletaCliente();

        Task<Uri> InsereDadosCliente(ApplicationCliente usuario);

        Task<Uri> AlteraDadosCliente(ApplicationCliente usuario);

        Task<Uri> RemoveDadosCliente(int id);

        Task<ApplicationCliente> BuscaClientePorId(int id);

        Task<ApplicationCliente> BuscaClienteParaValidacao(string email, string senha);
    }
}
