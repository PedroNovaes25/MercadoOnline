using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Output
{
    public class UsuarioOutputDTO
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}
