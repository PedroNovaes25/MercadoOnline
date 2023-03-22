using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MercadoDbContext _context;

        public ProdutoRepository(MercadoDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Produto>> GetAllProducts()
        {
            using (var context = _context)
            {
                return await context.Produtos.AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<Produto>> GetAllProductsFromCategoryId(int idCatgoria)
        {
            using (var context = _context)
            {
                return await context.Produtos.AsNoTracking()
                    .Where(c => c.CategoriaProduto.Any(x => x.IdCategoria == idCatgoria))
                    .ToListAsync();
            }
        }

        public async Task<Produto> GetProductById(int idProduto)
        {
            using (var context = _context)
            {
                return await context.Produtos.AsNoTracking()
                    .Where(p => p.IdProduto == idProduto)
                    .FirstAsync();
            }
        }

        public async Task<IEnumerable<Produto>> GetProductByName(string name)
        {
            using (var context = _context)
            {
                return await context.Produtos.AsNoTracking()
                    .Where(p => p.Nome.Contains(name))
                    .ToListAsync();
            }
        }
    }
}
