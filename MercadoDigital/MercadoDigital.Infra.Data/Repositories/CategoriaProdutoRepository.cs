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
    public class CategoriaProdutoRepository : RepositoryHandler, ICategoriaProdutoRepository
    {
        public CategoriaProdutoRepository(DbContextOptions<MercadoDbContext> options) : base(options)
        {
        }

        public async Task<CategoriaProduto> Create(CategoriaProduto categoriaProduto)
        {
            return await Insert(categoriaProduto);
        }
    }
}
