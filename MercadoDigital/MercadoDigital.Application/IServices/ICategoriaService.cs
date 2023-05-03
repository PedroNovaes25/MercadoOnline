
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaOutputDTO>> GetAllCategories();
        Task<IEnumerable<CategoriaOutputDTO>> GetCategoryByName(string name);
        Task<CategoriaOutputDTO> GetCategoryById(int idCategory);
        Task<bool> Create(CategoriaInputDTO categoriaDTO);
        Task<bool> Update(CategoriaInputDTO categoriaDTO, int idCategoria);
        Task<bool> Delete(int idCategoria);
    }
}
