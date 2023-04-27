using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Input
{
    public class PedidoInputDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public double ValorPedido { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public DateTime DataCompra { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "O {0} deve ser maior que 0")]
        public int IdUsuario { get; set; }
    }
}
