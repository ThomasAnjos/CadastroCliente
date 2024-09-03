using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Application.Models
{
    public class ApplicationUsuario
    {
        public ApplicationUsuario() { }

        public ApplicationUsuario(int Id, string UsuarioNome, string UsuarioEmail, string UsuarioSenha)
        {
            UsuarioNome = UsuarioNome;
            UsuarioEmail = UsuarioEmail;
            UsuarioSenha = UsuarioSenha;
            UsuarioId = Id;
        }

        [Key, Display(Name = "Id")]
        public int UsuarioId { get; set; }

        private string _nome;
        [Required, StringLength(50), Display(Name = "Nome")]
        public string UsuarioNome
        {
            get => _nome;
            set
            {
                if (value.Length <= 50)
                {
                    _nome = value;
                }
                else
                {
                    throw new ArgumentException("Nome maior que o permitido!");
                }
            }
        }

        private string _email;
        [Required, StringLength(50), Display(Name = "Email")]
        public string UsuarioEmail
        {
            get => _email;
            set
            {
                if (value == null || value.Length <= 50)
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Email maior que o permitido!");
                }
            }
        }

        private string _senha;
        [Required, StringLength(30), Display(Name = "Senha")]
        public string UsuarioSenha
        {
            get => _senha;
            set
            {
                if (value == null || value.Length <= 30)
                {
                    _senha = value;
                }
                else
                {
                    throw new ArgumentException("Senha maior que o permitido!");
                }
            }
        }
    }
}
