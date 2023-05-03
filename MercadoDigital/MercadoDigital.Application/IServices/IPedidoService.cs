using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoOutputDTO>> GetAllPedidosByUserId(int userId);
        Task<PedidoOutputDTO> GetPedidosById(int idPedido);
        Task<bool> Create(PedidoInputDTO pedidoDTO);
    }
}
