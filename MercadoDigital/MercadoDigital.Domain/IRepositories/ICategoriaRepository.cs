using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllCategories();
        Task<IEnumerable<Categoria>> GetCategoryByName(string name);
        Task<Categoria> GetCategoryById(int idCategory);
        Task<Categoria> Create(Categoria categoria);
        Task<bool> Update(Categoria categoria);
        Task<bool> Delete(Categoria categoria);
    }
}
