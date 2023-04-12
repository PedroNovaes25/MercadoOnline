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
        Task<IEnumerable<Pedido>>GetAllPedidosByUserId(int userId);
        Task<Pedido> GetPedidosById(int idPedido);
        Task<Pedido> Create(Pedido pedido);
    }
}
