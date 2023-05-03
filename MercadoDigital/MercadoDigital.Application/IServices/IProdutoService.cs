using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoOutputDTO>> GetAllProducts();
        Task<IEnumerable<ProdutoOutputDTO>> GetAllProductsFromCategoryId(int idCatgoria);
        Task<ProdutoOutputDTO> GetProductById(int idProduto);
        Task<IEnumerable<ProdutoOutputDTO>> GetProductByName(string name);
        Task<bool> Create(ProdutoInputDTO produtoDTO);
        Task<bool> Update(ProdutoInputDTO produtoDTO, int idProduto);
        Task<bool> Delete(int idProduto);
    }
}
