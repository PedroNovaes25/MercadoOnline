using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface IEstoqueService
    {
        Task<IEnumerable<EstoqueProdutoOutputDTO>> GetAllEstoque();
        Task<EstoqueProdutoOutputDTO> GetEstoqueById(int idEstoque);
        Task<EstoqueProdutoOutputDTO> GetEstoqueByProductId(int idProduto);
        Task<bool> Create(EstoqueInputDTO estoque, int idEstoque);
        Task<bool> Update(EstoqueInputDTO estoque);
        Task<bool> Delete(int idEstoque);
    }
}
