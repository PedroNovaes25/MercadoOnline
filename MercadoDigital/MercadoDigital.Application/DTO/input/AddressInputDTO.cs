using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Input
{
    public class AddressInputDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [StringLength(250, MinimumLength = 4, ErrorMessage = "O {0} deve conter entre 4 a 250 caracteres.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [MinLength(1)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [StringLength(250, MinimumLength = 4, ErrorMessage = "O {0} deve conter entre 4 a 250 caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [StringLength(250, MinimumLength = 4, ErrorMessage = "O {0} deve conter entre 4 a 250 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O {0} deve conter 2 caracteres.")]
        public string UF { get; set; }

        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "O {0} deve ser maior que 0")]
        public int IdUsuario { get; set; }
    }
}
