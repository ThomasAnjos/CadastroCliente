using CadastroCliente.Application.Interface;
using CadastroCliente.Application.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

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
        public async Task<Uri> AlteraDadosUsuario(ApplicationUsuario usuario)
        {
            using (var client = new HttpClient())
            {
                var usuarioAtualizar = new ApplicationUsuario
                {
                    UsuarioId = usuario.UsuarioId,
                    UsuarioNome = "Encoder",
                    UsuarioEmail = usuario.UsuarioEmail,
                    UsuarioSenha = usuario.UsuarioSenha
                };

                string json = JsonConvert.SerializeObject(usuarioAtualizar);
                client.BaseAddress = new System.Uri("https://localhost:44316/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                _response = await client.PutAsync("Usuario/Api/AlteraUsuarios", content);
            }

            return _response.Headers.Location;
        }


        public async Task<List<ApplicationUsuario>> BuscaListaCompletaUsuario()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:44316/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ApplicationUsuario usuario = null;
            HttpResponseMessage response = await _httpClient.GetAsync("Usuario/Api/BuscaTodosUsuarios");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                _usuarios = JsonConvert.DeserializeObject<List<ApplicationUsuario>>(responseContent);
            }

            return _usuarios;
        }

        public async Task<ApplicationUsuario> BuscaUsuarioParaValidacao(string email, string senha)
        {
            return null;
        }

        public async Task<ApplicationUsuario> BuscaUsuarioPorId(int Id)
        {
            string apiUrl = "https://localhost:44316/Usuario/Api/BuscaUsuarioPorId/" + Id; // Substitua "123" pelo ID desejado

            ApplicationUsuario usuario = new ApplicationUsuario();

            using (HttpClient client = new HttpClient())
            {
                // Fazer a requisição GET
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Verificar se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Ler o conteúdo da resposta como string
                    string result = await response.Content.ReadAsStringAsync();

                    // Desserializar o JSON para o objeto Produto
                    usuario = JsonConvert.DeserializeObject<ApplicationUsuario>(result);
                }
            }

            return usuario;
        }

        public async Task<Uri> InsereDadosUsuario(ApplicationUsuario usuario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44316/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = new ApplicationUsuario() { UsuarioNome = usuario.UsuarioNome, UsuarioEmail = usuario.UsuarioEmail, UsuarioSenha = usuario.UsuarioSenha };
                _response = await client.PostAsJsonAsync("Usuario/Api/AdicionaUsuario", json);
            }

            return _response.Headers.Location;
        }

        public async Task<Uri> RemoveDadosUsuario(int id)
        {
            string apiUrl = "https://localhost:44316/Usuario/Api/ApagarUsuario/" + id;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(apiUrl);
            }

            return _response.Headers.Location;
        }
    }
}
