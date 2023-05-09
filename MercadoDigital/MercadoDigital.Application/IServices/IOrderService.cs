using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderOutputDTO>> GetAllOdersByUserId(int userId);
        Task<OrderOutputDTO> GetOdersById(int orderId);
        Task<bool> Create(OrderInputDTO orderDTO);
    }
}
