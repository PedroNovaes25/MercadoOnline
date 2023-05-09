using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductOutputDTO>> GetAllProducts();
        Task<IEnumerable<ProductOutputDTO>> GetAllProductsFromCategoryId(int categoryId);
        Task<ProductOutputDTO> GetProductById(int productId);
        Task<IEnumerable<ProductOutputDTO>> GetProductByName(string name);
        Task<bool> Create(ProductInputDTO productDTO);
        Task<bool> Update(ProductInputDTO productDTO, int productId);
        Task<bool> Delete(int productId);
    }
}
