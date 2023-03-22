using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Models
{
    [NotMapped]
    public class EstoqueEProduto
    {
        public EstoqueEProduto(int quantidade, int idEstoque, int idProduto, string nomeProduto, DateTime vencimento, string descricao, double preco)
        {
            Quantidade = quantidade;
            IdEstoque = idEstoque;
            IdProduto = idProduto;
            NomeProduto = nomeProduto;
            Vencimento = vencimento;
            Descricao = descricao;
            Preco = preco;
        }

        public int Quantidade { get; }
        public int IdEstoque { get; }
        public int IdProduto { get; }
        public string NomeProduto { get; }
        public DateTime Vencimento { get;}
        public string Descricao { get; }
        public double Preco { get; }
    }
}
