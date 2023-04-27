using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.DTO.Output
{
    internal class PedidoOutputDTO
    {
        public int IdPedido { get; set; }
        public double ValorPedido { get; set; }
        public DateTime DataCompra { get; set; }
        public int IdUsuario { get; set; }
        public List<PedidoItemOutput> PedidoItems { get; set; }
    }
}
