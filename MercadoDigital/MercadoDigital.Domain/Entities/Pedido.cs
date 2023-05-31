using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoDigital.Domain.Entities.Identity;

namespace MercadoDigital.Domain.Entities
{
    public class Pedido
    {
        public Pedido(double valorPedido, DateTime dataCompra, int userId)
        {
            ValorPedido = valorPedido;
            DataCompra = dataCompra;
            UserId = userId;
        }

        public int IdPedido { get; set; }
        public double ValorPedido { get; set; }
        public DateTime DataCompra { get; set; } //Tentar pegar o dateTime na persistencia no banco, se for possível, transformar dado apenas em get
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<PedidoItem>? PedidoItem { get; set; }
    }
}
