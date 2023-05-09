using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IProductRepository 
    {
        Task<IEnumerable<Produto>> GetAllProducts();
        Task<IEnumerable<Produto>> GetAllProductsFromCategoryId(int categoryId);
        Task<Produto> GetProductById(int productId);
        Task<IEnumerable<Produto>> GetProductByName(string name);
        Task<bool> Create(Produto category);
        Task<bool> Update(Produto category);
        Task<bool> Delete(Produto category);
    }
}
