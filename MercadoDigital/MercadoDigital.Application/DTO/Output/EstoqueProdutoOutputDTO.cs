using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Output
{
    public class EstoqueProdutoOutputDTO
    {
        public int IdEstoque { get; set ;}
        public int Quantidade { get; set ;}
        public string NomeProduto { get; set ;}
        public DateTime Vencimento { get; set ;}
        public string Descricao { get; set ;}
        public double Preco { get; set; }
        public int IdProduto { get; set ;}
    }
}
