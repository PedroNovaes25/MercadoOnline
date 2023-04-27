using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Input
{
    public class UsuarioInputDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public DateTime Nascimento { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [Range(18, Int32.MaxValue, ErrorMessage = "A {0} miníma é de 18 anos.")]
        public int Idade { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Sexo { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Celular { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Password { get; set; }
    }
}
