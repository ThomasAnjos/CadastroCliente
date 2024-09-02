using Core.Entitites;
using Core.Interfaces;
using Infrastructure.Dto;
using Infrastructure.Interface;
using Infrastructure.Repositories;

namespace Core.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private Cliente _cliente;
        private ClienteDto _clienteDto;

        public ClienteService(IClienteRepository clienteRepository, Cliente cliente, ClienteDto clienteDto)
        {
            _clienteRepository = clienteRepository;
            _cliente = cliente;
            _clienteDto = clienteDto;
        }

        public async Task<int> Adicionar(Cliente entity)
        {
            _clienteDto.ClienteNome = entity.ClienteNome;
            _clienteDto.ClienteEmail = entity.ClienteEmail;
            _clienteDto.ClienteLogotipo = entity.ClienteLogotipo;

            var cliente = await _clienteRepository.Adicionar(_clienteDto);

            return cliente;
        }

        public async Task<int> Alterar(Cliente entity)
        {
            _clienteDto.ClienteNome = entity.ClienteNome;
            _clienteDto.ClienteEmail = entity.ClienteEmail;
            _clienteDto.ClienteLogradouro = entity.ClienteLogradouro;
            _clienteDto.ClienteLogotipo = entity.ClienteLogotipo;

            var result = await _clienteRepository.Alterar(_clienteDto);
            return result;
        }

        public async Task<int> Apagar(int Id)
        {
            var result = await _clienteRepository.Apagar(Id);
            return result;
        }

        public async Task<Cliente> LeituraPorId(int Id)
        {
            var Cliente = await _clienteRepository.LeituraPorId(Id);

            _cliente.ClienteNome = Cliente.ClienteNome;
            _cliente.ClienteEmail = Cliente.ClienteEmail;
            _cliente.ClienteLogradouro = Cliente.ClienteLogradouro;
            _cliente.ClienteLogotipo = Cliente.ClienteLogotipo;
            _cliente.ClienteId = Cliente.ClienteId;

            return _cliente;
        }

        public async Task<List<Cliente>> ListaTodos()
        {
            var listaClientes = await _clienteRepository.ListaTodos();
            Cliente cliente = null;
            List<Cliente> _listCliente = new List<Cliente>();

            foreach (var item in listaClientes.ToList())
            {
                cliente = new Cliente();
                cliente.ClienteNome = item.ClienteNome;
                cliente.ClienteEmail = item.ClienteEmail;
                cliente.ClienteLogradouro = item.ClienteLogradouro;
                cliente.ClienteLogotipo = item.ClienteLogotipo;
                cliente.ClienteId = item.ClienteId;

                _listCliente.Add(cliente);
            }

            return _listCliente;
        }
    }
}
