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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public PedidoRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }
        public async Task<bool> Create(Pedido pedido)
        {
            return await _generalRepository.Insert(pedido);
        }
        public async Task<IEnumerable<Pedido>> GetAllPedidosByUserId(int userId)
        {

            return await _generalRepository.CommandExecuter
            (
                p => p.Pedidos
                .AsNoTracking()
                .Include(p => p.PedidoItem)
                .ThenInclude(pi => pi.Produto)
                .Where(p => p.IdUsuario == userId)
                .OrderByDescending(p => p.DataCompra)
                .ToListAsync()
            );
            //Talvez esse where gere problema por conta do p.idusuario
        }
        public async Task<Pedido> GetPedidosById(int idPedido)
        {
            return (await _generalRepository.CommandExecuter
            (
                p => p.Pedidos
                .AsNoTracking()
                .Include(p => p.PedidoItem)
                .ThenInclude(pi => pi.Produto)
                .Where(p => p.IdPedido == idPedido)
                .FirstOrDefaultAsync()
            ))!;
        }
    }
}
