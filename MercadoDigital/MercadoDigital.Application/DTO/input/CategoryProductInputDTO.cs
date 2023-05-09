using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Input
{
    public class CategoryProductInputDTO
    {
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "O {0} deve ser maior que 0")]
        public int IdCategoria { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "O {0} deve ser maior que 0")]
        public int IdProduto { get; set; }
    }
}
