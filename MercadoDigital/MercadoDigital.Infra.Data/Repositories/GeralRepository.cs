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
    public class GeralRepository : IRepositoryHandler
    {
        private readonly DbContext _context;

        public GeralRepository(MercadoDbContext context)
        {
            this._context = context;
        }

        public async Task<T> Create<T>(T entity) where T : class
        {
            _context.Add<T>(entity);
            await SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete<T>(T entity) where T : class
        {
            _context.Remove<T>(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> Update<T>(T entity) where T : class
        {
            _context.Update<T>(entity);
            return await SaveChangesAsync();
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);

        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
