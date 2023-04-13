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
    public class ProdutoRepository : RepositoryHandler, IProdutoRepository
    {
        public ProdutoRepository(DbContextOptions<MercadoDbContext> options) : base(options)
        {
        }

        public async Task<bool> Create(Produto produto)
        {
            return await Insert(produto);
        }
        public async Task<bool> Delete(Produto produto)
        {
            return await Remove(produto);
        }
        public async Task<bool> Update(Produto produto)
        {
            return await Updates(produto);
        }
        public async Task<IEnumerable<Produto>> GetAllProducts()
        {
            return await CommandExecuterTeste2
            (
                p => p.Produtos
                .AsNoTracking()
                .ToListAsync()
            );
        }
        public async Task<IEnumerable<Produto>> GetAllProductsFromCategoryId(int idCatgoria)
        {
            return await CommandExecuterTeste2
            (
                p => p.Produtos
                .AsNoTracking()
                .Include(c => c.CategoriaProduto)
                .ThenInclude(c => c.Categoria)
                .Where(c => c.CategoriaProduto
                .Any(x => x.IdCategoria == idCatgoria))
                .ToListAsync()
            );
        }
        public async Task<Produto> GetProductById(int idProduto)
        {
            return (await CommandExecuterTeste2
            (   
                p => p.Produtos
                .AsNoTracking()
                .Where(p => p.IdProduto == idProduto)
                .FirstOrDefaultAsync()
            ))!;
        }
        public async Task<IEnumerable<Produto>> GetProductByName(string name)
        {
            return await CommandExecuterTeste2
            (
                p => p.Produtos
                .AsNoTracking()
                .Where(p => p.Nome.Contains(name))
                .ToListAsync()
            );
        }
    }
}
