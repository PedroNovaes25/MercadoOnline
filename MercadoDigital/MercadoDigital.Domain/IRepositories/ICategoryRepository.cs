using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Categoria>> GetAllCategories();
        Task<IEnumerable<Categoria>> GetCategoryByName(string name);
        Task<Categoria> GetCategoryById(int idCategory);
        Task<bool> Create(Categoria category);
        Task<bool> Update(Categoria category);
        Task<bool> Delete(Categoria category);
    }
}
