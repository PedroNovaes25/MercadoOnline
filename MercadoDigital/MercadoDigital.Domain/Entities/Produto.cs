using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities
{
    public class Produto
    {
        public Produto(string nome, DateTime vencimento, string descricao, double preco)
        {
            Nome = nome;
            Vencimento = vencimento;
            Descricao = descricao;
            Preco = preco;
        }

        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public DateTime Vencimento { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public Estoque Estoque { get; set; }
        public List<CategoriaProduto> CategoriaProduto { get; set; }
        public List<PedidoItem> PedidoItem { get; set; }
    }
}
