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
    public class GeneralRepository : IGeneralRepository<MercadoDbContext>
    {
        private MercadoDbContext _context { get; }

        public GeneralRepository(MercadoDbContext options)
        {
            _context = options;
        }

        public async Task<Entity> Insert<Entity>(Entity entity) where Entity : class
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<bool> Remove<Entity>(Entity entity) where Entity : class
        {
            _context.Remove(entity);
            return (await _context!.SaveChangesAsync()) > 0;
        }
        public void RemoveRange<Entity>(Entity[] entities) where Entity : class
        {
            _context.RemoveRange(entities);
        }
        public async Task<bool> Update<Entity>(Entity entity) where Entity : class
        {
            _context.Update(entity);
            return (await _context!.SaveChangesAsync()) > 0;
        }

        public TValue CommandExecuter<TValue>(Func<MercadoDbContext, TValue> action)
        {
            return action.Invoke(_context);
        }
    }
}
