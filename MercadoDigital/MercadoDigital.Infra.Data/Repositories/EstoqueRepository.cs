using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Domain.Models;
using MercadoDigital.Infra.Data.Connection;
using Microsoft.EntityFrameworkCore;

namespace MercadoDigital.Infra.Data.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly MercadoDbContext _context;

        public EstoqueRepository(MercadoDbContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<EstoqueEProduto>> GetAllEstoque()
        {
            using (var context = _context) 
            {
                return await context.Estoques.AsNoTracking()
                    .Select
                    (
                        e => new EstoqueEProduto(e.Quantidade, e.IdEstoque, 
                        e.Produto.IdProduto, e.Produto.Nome, e.Produto.Vencimento,
                        e.Produto.Descricao, e.Produto.Preco)
                    ).ToListAsync();
            }
        }

        public async Task<EstoqueEProduto> GetEstoqueById(int idEstoque)
        {
            using (var context = _context)
            {
                return await context.Estoques.AsNoTracking()
                    .Select
                    (
                        e => new EstoqueEProduto(e.Quantidade, e.IdEstoque,
                        e.Produto.IdProduto, e.Produto.Nome, e.Produto.Vencimento,
                        e.Produto.Descricao, e.Produto.Preco)
                    ).Where(e => e.IdEstoque == idEstoque).FirstAsync();
            }
        }

        public async Task<EstoqueEProduto> GetEstoqueByProductId(int idProduto)
        {
            using (var context = _context)
            {
                return await context.Estoques.AsNoTracking()
                    .Select
                    (
                        e => new EstoqueEProduto(e.Quantidade, e.IdEstoque,
                        e.Produto.IdProduto, e.Produto.Nome, e.Produto.Vencimento,
                        e.Produto.Descricao, e.Produto.Preco)
                    ).Where(e => e.IdProduto == idProduto).FirstAsync();
            }
        }

        public async Task<bool> CreateAndUpdate(Estoque estoque) 
        {
            using (var context = _context) 
            {
                context.Update(estoque);
                return await (context.SaveChangesAsync()) > 0;
            }
        }
    }
}
