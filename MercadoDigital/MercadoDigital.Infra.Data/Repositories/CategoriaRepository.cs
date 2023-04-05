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
        private readonly MercadoDbContext _context;

        public CategoriaRepository(MercadoDbContext categoriaDbContext)
        {
            this._context = categoriaDbContext;
        }

        public async Task<IEnumerable<Categoria>> GetAllCategories()
        {
            using (var context = _context)
            {
                return await context.Categorias.AsNoTracking()
                    .OrderBy(c => c.Nome)
                    .ToListAsync();
            }
        }

        public async Task<Categoria> GetCategoryById(int idCategory)
        {
            using (var context = _context) 
            {
                return await context.Categorias.AsNoTracking()
                .Where(c => c.IdCategoria == idCategory)
            }
        }

        public async Task<IEnumerable<Categoria>> GetCategoryByName(string name)
        {
            using (var context = _context)
            {
                return await context.Categorias.AsNoTracking()
                    .OrderBy(c => c.Nome)
                    .Where(c => c.Nome.ToUpper().Contains(name.ToUpper()))
                    .ToListAsync();
            }
        }
    }
}
