using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        [Required]
        public string ClienteNome { get; set; }
        [Required]
        public string ClienteEmail { get; set; }
        [Required]
        public string ClienteLogradouro { get; set; }
        [Required]
        public byte[] ClienteLogotipo { get; set; }
    }
}
