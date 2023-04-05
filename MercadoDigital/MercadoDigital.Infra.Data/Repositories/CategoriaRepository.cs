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
    public class CategoriaRepository : RepositoryHandler, ICategoriaRepository
    {
        public CategoriaRepository(DbContextOptions<MercadoDbContext> options) : base(options)
        {
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            return await Insert(categoria);
        }
        public async Task<bool> Delete(Categoria categoria)
        {
            return await Remove(categoria);
        }
        public async Task<bool> Update(Categoria categoria)
        {
            return await Updates(categoria);
        }
        public async Task<IEnumerable<Categoria>> GetAllCategories()
        {
            var commandResult = await CommandExecuterTeste1
                (
                    x => x.Categorias.AsNoTracking()
                    .OrderBy(c => c.Nome)
                    .ToListAsync()
                );

            return await commandResult;
        }
        //Verificar qual é a melhor abordagem CommandExecuterTeste2 ou CommandExecuterTeste1
        public async Task<Categoria> GetCategoryById(int idCategory)
        {
            return (await CommandExecuterTeste2
            (
                c => c.Categorias.AsNoTracking()
                .Where(c => c.IdCategoria == idCategory)
                .FirstOrDefaultAsync()
            ))!;
        }
        public async Task<IEnumerable<Categoria>> GetCategoryByName(string name)
        {
            var commandResult = await CommandExecuterTeste1
                (
                    c => c.Categorias.AsNoTracking()
                    .OrderBy(c => c.Nome)
                    .Where(c => c.Nome.ToUpper().Contains(name.ToUpper()))
                    .ToListAsync()
                );

              return await commandResult;
        }
    }
}
