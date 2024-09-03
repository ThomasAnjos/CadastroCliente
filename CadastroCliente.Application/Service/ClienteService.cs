using CadastroCliente.Application.Interface;
using CadastroCliente.Application.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CadastroCliente.Application.Service
{
    public class ClienteService : IClienteService
    {
        private HttpClient _httpClient;
        private HttpResponseMessage _response;
        private List<ApplicationCliente> _clientes;
        private ApplicationCliente _cliente;

        public ClienteService(HttpClient httpClient, HttpResponseMessage response, List<ApplicationCliente> clientes, ApplicationCliente cliente)
        {
            _httpClient = httpClient;
            _response = response;
            _clientes = clientes;
            _cliente = cliente;
        }
        
        public async Task<Uri> AlteraDadoscliente(ApplicationCliente cliente)
        {
            //using (var client = new HttpClient())
            //{
            //    var clienteAtualizar = new ApplicationCliente
            //    {
            //        clienteId = cliente.clienteId,
            //        clienteNome = "Encoder",
            //        clienteEmail = cliente.clienteEmail,
            //        clienteSenha = cliente.clienteSenha
            //    };

            //    string json = JsonConvert.SerializeObject(clienteAtualizar);
            //    client.BaseAddress = new System.Uri("https://localhost:44316/");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    //var json = new ApplicationCliente() { clienteId = cliente.clienteId, clienteNome = cliente.clienteNome, clienteEmail = cliente.clienteEmail, clienteSenha = cliente.clienteSenha };
            //    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //    _response = await client.PutAsync("cliente/Api/Alteraclientes", content);
            //}

            return _response.Headers.Location;
        }

        public async Task<List<ApplicationCliente>> BuscaListaCompletaCliente()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:44316/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ApplicationCliente cliente = null;
            HttpResponseMessage response = await _httpClient.GetAsync("Cliente/Api/BuscaTodosClientes");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                _clientes = JsonConvert.DeserializeObject<List<ApplicationCliente>>(responseContent);
            }

            return _clientes;
        }

        public async Task<ApplicationCliente> BuscaClienteParaValidacao(string email, string senha)
        {
            return null;
        }

        public async Task<ApplicationCliente> BuscaClientePorId(int Id)
        {
            string apiUrl = "https://localhost:44316/Cliente/Api/BuscaClientePorId/" + Id;

            ApplicationCliente cliente = new ApplicationCliente();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    cliente = JsonConvert.DeserializeObject<ApplicationCliente>(result);
                }
            }

            return cliente;
        }

        public async Task<Uri> InsereDadosCliente(ApplicationCliente cliente)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44316/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = new ApplicationCliente() { clienteNome = cliente.clienteNome, 
                                                      clienteEmail = cliente.clienteEmail, 
                                                      clienteLogradouro = cliente.clienteLogradouro,
                                                      clienteLogotipo = cliente.clienteLogotipo};
                _response = await client.PostAsJsonAsync("Cliente/Api/AdicionaCliente", json);
            }

            return _response.Headers.Location;
        }

        public async Task<Uri> RemoveDadosCliente(int id)
        {
            string apiUrl = "https://localhost:44316/Cliente/Api/ApagarCliente/" + id;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(apiUrl);
            }

            return _response.Headers.Location;
        }

        public Task<Uri> AlteraDadosCliente(ApplicationCliente usuario)
        {
            throw new NotImplementedException();
        }
    }
}