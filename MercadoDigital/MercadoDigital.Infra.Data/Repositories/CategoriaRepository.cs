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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public CategoriaRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<bool> Create(Categoria categoria)
        {
            return await _generalRepository.Insert(categoria);
        }
        public async Task<bool> Delete(Categoria categoria)
        {
            return await _generalRepository.Remove(categoria);
        }
        public async Task<bool> Update(Categoria categoria)
        {
            return await _generalRepository.Update(categoria);
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

        public async Task<Categoria> GetCategoryById(int idCategory)
        {
            return (await _generalRepository.CommandExecuter
            (
                c => c.Categorias.AsNoTracking()
                .Where(c => c.IdCategoria == idCategory)
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
