using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Output
{
    public class ProdutoOutputDTO
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public DateTime Vencimento { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}
