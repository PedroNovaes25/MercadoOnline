using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities
{
    public class PedidoItem
    {
        public PedidoItem(int quantidade, double subtotal)
        {
            Quantidade = quantidade;
            Subtotal = subtotal;
        }

        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public double Subtotal { get; set; }
        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }
    }
}
