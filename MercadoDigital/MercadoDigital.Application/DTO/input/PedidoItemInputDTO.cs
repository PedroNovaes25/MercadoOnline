using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Input
{
    public class PedidoItemInputDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "O {0} deve ser maior que 0")]
        public int IdPedido { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "O {0} deve ser maior que 0")]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "A {0} deve ser maior que 0")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public double SubTotal { get; set; }
    }
}
