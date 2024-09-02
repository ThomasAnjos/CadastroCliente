using CadastroCliente.App.Interface;
using CadastroCliente.App.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;

namespace CadastroCliente.App.Service
{
    public class UsuarioService : IUsuarioService
    {
        private HttpClient _httpClient;
        private HttpResponseMessage _response;
        private List<Usuario> _usuarios;
        private Usuario _usuario;

        public UsuarioService(HttpClient httpClient, HttpResponseMessage response, List<Usuario> usuarios, Usuario usuario)
        {
            _httpClient = httpClient;
            _response = response;
            _usuarios = usuarios;
            _usuario = usuario;
        }
        public Task AlteraDadosUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usuario>> BuscaListaCompletaUsuario()
        {
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri("https://viacep.com.br/ws/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            string cep = string.Empty;

            _response = await _httpClient.GetAsync($"{cep}/json/");

            if (_response.IsSuccessStatusCode)
            {
                var json = await _response.Content.ReadAsStringAsync();
                _usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);
            }

            return _usuarios;
        }

        public async Task<Usuario> BuscaUsuarioParaValidação(string email, string senha)
        {
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri("https://viacep.com.br/ws/");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            string cep = string.Empty;

            _response = await _httpClient.GetAsync($"{cep}/json/");

            if (_response.IsSuccessStatusCode)
            {
                var json = await _response.Content.ReadAsStringAsync();
                _usuario = JsonConvert.DeserializeObject<Usuario>(json);
            }

            return _usuario;
        }

        public Task<Usuario> BuscaUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsereDadosUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task RemoveDadosUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
