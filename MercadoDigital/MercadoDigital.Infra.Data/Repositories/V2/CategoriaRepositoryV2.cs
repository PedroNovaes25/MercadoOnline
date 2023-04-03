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
    public class CategoriaRepositoryV2 : RepositoryHandler, ICategoriaRepository
    {
        public CategoriaRepositoryV2(DbContextOptions<MercadoDbContext> options) : base(options)
        {
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
            return await CommandExecuterTeste2
                (
                    c => c.Categorias.AsNoTracking()
                    .Where(c => c.IdCategoria == idCategory)
                    .FirstAsync()
                );

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

    public class Teste 
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly RepositoryHandler _repositoryHandler;

        public Teste(ICategoriaRepository categoriaRepository, RepositoryHandler repositoryHandler)
        {
            this._categoriaRepository = categoriaRepository;
            this._repositoryHandler = repositoryHandler;
        }

        public void Tee() 
        {

            //_repositoryHandler.Create<>
        }
    }
}
