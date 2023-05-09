
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryOutputDTO>> GetAllCategories();
        Task<IEnumerable<CategoryOutputDTO>> GetCategoryByName(string name);
        Task<CategoryOutputDTO> GetCategoryById(int categoryId);
        Task<bool> Create(CategorynputDTO categoryDTO);
        Task<bool> Update(CategorynputDTO categoriaDTO, int categoryId);
        Task<bool> Delete(int categoryId);
    }
}
