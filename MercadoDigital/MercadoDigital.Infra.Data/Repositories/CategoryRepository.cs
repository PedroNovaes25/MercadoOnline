using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Connection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public CategoryRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<bool> Create(Categoria category)
        {
            return await _generalRepository.Insert(category);
        }
        public async Task<bool> Delete(Categoria category)
        {
            return await _generalRepository.Remove(category);
        }
        public async Task<bool> Update(Categoria category)
        {
            return await _generalRepository.Update(category);
        }
        public async Task<IEnumerable<Categoria>> GetAllCategories()
        {
            return await _generalRepository.CommandExecuter
            (
                x => x.Categorias.AsNoTracking()
                .OrderBy(c => c.Nome)
                .ToListAsync()
            );
        }

        public async Task<Categoria> GetCategoryById(int categoryId)
        {
            return (await _generalRepository.CommandExecuter
            (
                c => c.Categorias.AsNoTracking()
                .Where(c => c.IdCategoria == categoryId)
                .FirstOrDefaultAsync()
            ))!;
        }
        public async Task<IEnumerable<Categoria>> GetCategoryByName(string name)
        {
            return await _generalRepository.CommandExecuter
            (
                c => c.Categorias.AsNoTracking()
                .OrderBy(c => c.Nome)
                .Where(c => c.Nome.ToUpper().Contains(name.ToUpper()))
                .ToListAsync()
            );
        }
    }
}
