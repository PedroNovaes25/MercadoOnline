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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public OrderItemRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<bool> Create(PedidoItem orderItem)
        {
            return await _generalRepository.Insert(orderItem);
        }
    }
}
