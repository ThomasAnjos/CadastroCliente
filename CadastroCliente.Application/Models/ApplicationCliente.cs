using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Application.Models
{
    public class ApplicationCliente
    {
        public ApplicationCliente() { }

        public ApplicationCliente(int Id, string ClienteNome, string ClienteEmail, string ClienteLogradouro, byte[] ClienteLogotipo)
        {
            clienteId = Id;
            clienteNome = ClienteNome;
            clienteEmail = ClienteEmail;
            clienteLogradouro = ClienteLogradouro;
            clienteLogotipo = ClienteLogradouro;
        }

        [Key, Display(Name = "Id")]
        public int clienteId { get; set; }

        private string _nome;
        [Required, StringLength(50), Display(Name = "Nome")]
        public string clienteNome
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
        public string clienteEmail
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

        private string _logradouro;
        [Required, StringLength(200), Display(Name = "Logradouro")]
        public string clienteLogradouro
        {
            get => _logradouro;
            set
            {
                if (value == null || value.Length <= 200)
                {
                    _logradouro = value;
                }
                else
                {
                    throw new ArgumentException("Logradouro maior que o permitido!");
                }
            }
        }

        private string _logotipo;
        [Required, StringLength(200), Display(Name = "Logradouro")]
        public string clienteLogotipo
        {
            get => _logotipo;
            set
            {
                if (value == null || value.Length <= 8000)
                {
                    _logotipo = value;
                }
                else
                {
                    throw new ArgumentException("Logradouro maior que o permitido!");
                }
            }
        }
    }
}