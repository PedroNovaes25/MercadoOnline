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
    public class PedidoItemRepository : RepositoryHandler, IPedidoItemRepository
    {
        public PedidoItemRepository(DbContextOptions<MercadoDbContext> options) : base(options)
        {
        }

        public async Task<bool> Create(PedidoItem pedidoItem)
        {
            return await Insert(pedidoItem);
        }
    }
}
