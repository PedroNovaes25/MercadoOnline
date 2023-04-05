using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IEstoqueRepository 
    {
        Task<IEnumerable<EstoqueEProduto>> GetAllEstoque();
        Task<EstoqueEProduto> GetEstoqueById(int idEstoque);
        Task<EstoqueEProduto> GetEstoqueByProductId(int idProduto);
        Task<bool> CreateOrUpdate(Estoque estoque);
        Task<bool> Delete(Estoque produto);
    }
}
