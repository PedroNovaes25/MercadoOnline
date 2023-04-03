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
        private readonly MercadoDbContext _context;

        public PedidoRepository(MercadoDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pedido>> GetAllPedidoByUserId(int userId)
        {
            using (var context = _context)
            {
                return await context.Pedidos.AsNoTracking()
                    .OrderByDescending(p => p.DataCompra)
                    .Include(p => p.PedidoItem)
                    .ThenInclude(pi => pi.Produto)
                    .Where(p => p.IdUsuario == userId).ToListAsync();
                //Talvez esse where gere problema por conta do p.idusuario
            }
        }

        public async Task<Pedido> GetPedidoById(int idPedido)
        {
            using (var context = _context)
            {
                return await context.Pedidos.AsNoTracking()
                    .Include(p => p.PedidoItem)
                    .ThenInclude(pi => pi.Produto)
                    .Where(p => p.IdPedido == idPedido).FirstAsync();
            }
        }
    }
}
