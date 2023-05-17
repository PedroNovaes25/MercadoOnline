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
    public class ProductRepository : IProductRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public ProductRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }
        public async Task<bool> Create(Produto product)
        {
            return await _generalRepository.Insert(new Produto[] { product });
        }
        public async Task<bool> Delete(Produto product)
        {
            return await _generalRepository.Remove(product);
        }
        public async Task<bool> Update(Produto product)
        {
            return await _generalRepository.Update(product);
        }
        public async Task<IEnumerable<Produto>> GetAllProducts()
        {
            return await _generalRepository.CommandExecuter
            (
                p => p.Produtos
                .AsNoTracking()
                .ToListAsync()
            );
        }
        public async Task<IEnumerable<Produto>> GetAllProductsFromCategoryId(int categoryId)
        {
            return await _generalRepository.CommandExecuter
            (
                p => p.Produtos
                .AsNoTracking()
                .Include(c => c.CategoriaProduto)
                .ThenInclude(c => c.Categoria)
                .Where(c => c.CategoriaProduto
                .Any(x => x.IdCategoria == categoryId))
                .ToListAsync()
            );
        }
        public async Task<Produto> GetProductById(int productId)
        {
            return (await _generalRepository.CommandExecuter
            (
                p => p.Produtos
                .AsNoTracking()
                .Where(p => p.IdProduto == productId)
                .FirstOrDefaultAsync()
            ))!;
        }
        public async Task<IEnumerable<Produto>> GetProductByName(string name)
        {
            return await _generalRepository.CommandExecuter
            (
                p => p.Produtos
                .AsNoTracking()
                .Where(p => p.Nome.Contains(name))
                .ToListAsync()
            );
        }
    }
}
