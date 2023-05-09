using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Input
{
    public class ProductInputDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public DateTime Vencimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public double Preco { get; set; }
    }
}
