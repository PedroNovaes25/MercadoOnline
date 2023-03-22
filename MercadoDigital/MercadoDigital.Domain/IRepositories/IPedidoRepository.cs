using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>>GetAllPedidoByUserId(int userId);
        Task<Pedido> GetPedidoById(int idPedido);
    }
}
