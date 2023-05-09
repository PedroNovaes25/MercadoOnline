using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Pedido>>GetAllOrdersByUserId(int userId);
        Task<Pedido> GetOrdersById(int oderId);
        Task<bool> Create(Pedido order);
    }
}
