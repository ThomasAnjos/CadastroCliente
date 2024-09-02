using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entitites
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioSenha { get; set; }
    }
}
