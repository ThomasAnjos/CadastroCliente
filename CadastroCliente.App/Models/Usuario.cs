using Newtonsoft.Json;

namespace CadastroCliente.App.Models
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(string UsuarioNome, string UsuarioEmail, string UsuarioSenha, DateTime UsuarioDataCadastro) 
        {
            usuarioNome = UsuarioNome;
            usuarioEmail = UsuarioEmail;
            usuarioSenha = UsuarioSenha;
        }

        [JsonProperty("UsuarioNome")]
        public string usuarioNome { get; set; }

        [JsonProperty("UsuarioEmail")]
        public string usuarioEmail { get; set; }

        [JsonProperty("UsuarioSenha")]
        public string usuarioSenha { get; set; }
    }
}
