using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        [Required]
        public string UsuarioNome { get; set; }
        [Required]
        public string UsuarioEmail { get; set; }
        [Required]
        public string UsuarioSenha { get; set; }
    }
}
