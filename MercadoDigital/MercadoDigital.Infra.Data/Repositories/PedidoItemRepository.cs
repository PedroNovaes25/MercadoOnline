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
    public class PedidoItemRepository : IPedidoItemRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public PedidoItemRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<PedidoItem> Create(PedidoItem pedidoItem)
        {
            return await _generalRepository.Insert(pedidoItem);
        }
    }
}
