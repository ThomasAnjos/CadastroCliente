using CadastroCliente.Application.Interface;
using CadastroCliente.Application.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CadastroCliente.Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private HttpClient _httpClient;
        private HttpResponseMessage _response;
        private List<ApplicationUsuario> _usuarios;
        private ApplicationUsuario _usuario;

        public UsuarioService(HttpClient httpClient, HttpResponseMessage response, List<ApplicationUsuario> usuarios, ApplicationUsuario usuario)
        {
            _httpClient = httpClient;
            _response = response;
            _usuarios = usuarios;
            _usuario = usuario;
        }
        public Task AlteraDadosUsuario(ApplicationUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApplicationUsuario>> BuscaListaCompletaUsuario()
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
                _usuarios = JsonConvert.DeserializeObject<List<ApplicationUsuario>>(json);
            }

            return _usuarios;
        }

        public async Task<ApplicationUsuario> BuscaUsuarioParaValidação(string email, string senha)
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
                _usuario = JsonConvert.DeserializeObject<ApplicationUsuario>(json);
            }

            return _usuario;
        }

        public Task<ApplicationUsuario> BuscaUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsereDadosUsuario(ApplicationUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task RemoveDadosUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
