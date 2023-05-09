using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Output
{
    public class StockProductOutputDTO
    {
        //Estoque
        public int IdEstoque { get; set ;}
        public int Quantidade { get; set ;}

        //Produto
        public int IdProduto { get; set ;}
        //Prop usada para testar Automapper por config
        //public string Nome { get; set ;}
        public string ProdutoNome { get; set ;}
        public DateTime Vencimento { get; set ;}
        public string Descricao { get; set ;}
        public double Preco { get; set; }
    }
}
