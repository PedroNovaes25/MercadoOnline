using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Domain.Models;
using MercadoDigital.Infra.Data.Connection;
using Microsoft.EntityFrameworkCore;

namespace MercadoDigital.Infra.Data.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public EstoqueRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<bool> CreateOrUpdate(Estoque estoque)
        {
            return await _generalRepository.Update(estoque);
        }
        public async Task<bool> Delete(Estoque produto)
        {
            return await _generalRepository.Remove(produto);
        }
        public async Task<IEnumerable<EstoqueEProduto>> GetAllEstoque()
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
        public async Task<EstoqueEProduto> GetEstoqueById(int idEstoque)
        {
            return (await _generalRepository.CommandExecuter
            (
                e => e.Estoques
                .AsNoTracking()
                .Where(e => e.IdEstoque == idEstoque)
                .Select
                (
                    e => new EstoqueEProduto(e.Quantidade, e.IdEstoque,
                    e.Produto.IdProduto, e.Produto.Nome, e.Produto.Vencimento,
                    e.Produto.Descricao, e.Produto.Preco)
                )
                .FirstOrDefaultAsync()
            ))!;
        }
        public async Task<EstoqueEProduto> GetEstoqueByProductId(int idProduto)
        {
            return (await _generalRepository.CommandExecuter
            (
                e => e.Estoques
                .AsNoTracking()
                .Where(e => e.IdProduto == idProduto)
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
