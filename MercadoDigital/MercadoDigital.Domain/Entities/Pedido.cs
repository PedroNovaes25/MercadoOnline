using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.Entities
{
    public class Pedido
    {
        public Pedido(double valorPedido, DateTime dataCompra)
        {
            ValorPedido = valorPedido;
            DataCompra = dataCompra;
        }

        public int IdPedido { get; set; }
        public double ValorPedido { get; set; }
        public DateTime DataCompra { get; set; } //Tentar pegar o dateTime na persistencia no banco, se for possível, transformar dado apenas em get
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public List<PedidoItem> PedidoItem { get; set; }
    }
}
