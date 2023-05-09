using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IStockRepository 
    {
        Task<IEnumerable<EstoqueEProduto>> GetAllStock();
        Task<EstoqueEProduto> GetStockById(int stockId);
        Task<EstoqueEProduto> GetStockByProductId(int productId);
        Task<bool> CreateOrUpdate(Estoque stock);
        Task<bool> Delete(Estoque produto);
    }
}
