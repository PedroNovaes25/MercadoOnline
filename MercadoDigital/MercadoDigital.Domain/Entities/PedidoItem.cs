using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities
{
    public class PedidoItem
    {
        public PedidoItem(int quantidade, double subtotal, int idProduto, int idPedido)
        {
            Quantidade = quantidade;
            Subtotal = subtotal;
            IdPedido = idPedido;
            IdProduto = idProduto;
        }

        public int Quantidade { get; set; }
        public double Subtotal { get; set; }
        public int IdProduto { get; set; }
        public Produto? Produto { get; set; }
        public int IdPedido { get; set; }
        public Pedido? Pedido { get; set; }
    }
}
