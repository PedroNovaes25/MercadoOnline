using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IProdutoRepository 
    {
        Task<IEnumerable<Produto>> GetAllProducts();
        Task<IEnumerable<Produto>> GetAllProductsFromCategoryId(int idCatgoria);
        Task<Produto> GetProductById(int idProduto);
        Task<IEnumerable<Produto>> GetProductByName(string name);
        Task<bool> Create(Produto produto);
        Task<bool> Update(Produto produto);
        Task<bool> Delete(Produto produto);
    }
}
