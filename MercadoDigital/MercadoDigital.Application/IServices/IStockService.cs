using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface IStockService
    {
        Task<IEnumerable<StockProductOutputDTO>> GetAllStock();
        Task<StockProductOutputDTO> GetStockById(int stockId);
        Task<StockProductOutputDTO> GetStockByProductId(int productId);
        Task<bool> Create(StockInputDTO stockDTO);
        Task<bool> Update(StockInputDTO stockDTO, int stockId);
        Task<bool> Delete(int stockId);
    }
}
