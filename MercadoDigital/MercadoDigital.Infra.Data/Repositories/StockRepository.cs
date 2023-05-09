using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Domain.Models;
using MercadoDigital.Infra.Data.Connection;
using Microsoft.EntityFrameworkCore;

namespace MercadoDigital.Infra.Data.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public StockRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<bool> CreateOrUpdate(Estoque stock)
        {
            return await _generalRepository.Update(stock);
        }
        public async Task<bool> Delete(Estoque stock)
        {
            return await _generalRepository.Remove(stock);
        }
        public async Task<IEnumerable<EstoqueEProduto>> GetAllStock()
        {
            return await _generalRepository.CommandExecuter
            (
                e => e.Estoques
                .AsNoTracking()
                .Select
                (
                    e => new EstoqueEProduto(e.Quantidade, e.IdEstoque,
                    e.Produto.IdProduto, e.Produto.Nome, e.Produto.Vencimento,
                    e.Produto.Descricao, e.Produto.Preco)
                ).ToListAsync()
            );
        }
        public async Task<EstoqueEProduto> GetStockById(int stockId)
        {
            return (await _generalRepository.CommandExecuter
            (
                e => e.Estoques
                .AsNoTracking()
                .Where(e => e.IdEstoque == stockId)
                .Select
                (
                    e => new EstoqueEProduto(e.Quantidade, e.IdEstoque,
                    e.Produto.IdProduto, e.Produto.Nome, e.Produto.Vencimento,
                    e.Produto.Descricao, e.Produto.Preco)
                )
                .FirstOrDefaultAsync()
            ))!;
        }
        public async Task<EstoqueEProduto> GetStockByProductId(int productId)
        {
            return (await _generalRepository.CommandExecuter
            (
                e => e.Estoques
                .AsNoTracking()
                .Where(e => e.IdProduto == productId)
                .Select
                (
                    e => new EstoqueEProduto(e.Quantidade, e.IdEstoque,
                    e.Produto.IdProduto, e.Produto.Nome, e.Produto.Vencimento,
                    e.Produto.Descricao, e.Produto.Preco)
                )
                .FirstOrDefaultAsync()
            ))!;
        }
    }
}
