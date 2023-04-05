using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Domain.Models;
using MercadoDigital.Infra.Data.Connection;
using Microsoft.EntityFrameworkCore;

namespace MercadoDigital.Infra.Data.Repositories
{
    public class EstoqueRepository : RepositoryHandler, IEstoqueRepository
    {
        public EstoqueRepository(DbContextOptions<MercadoDbContext> options) : base(options)
        {
        }

        public async Task<bool> CreateOrUpdate(Estoque estoque)
        {
            return await Updates(estoque);
        }
        public async Task<bool> Delete(Estoque produto)
        {
            return await Remove(produto);
        }
        public async Task<IEnumerable<EstoqueEProduto>> GetAllEstoque()
        {
            return await CommandExecuterTeste2
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
            return (await CommandExecuterTeste2
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
            return (await CommandExecuterTeste2
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
