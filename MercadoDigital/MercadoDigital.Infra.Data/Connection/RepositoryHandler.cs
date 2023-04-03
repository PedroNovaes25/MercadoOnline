using MercadoDigital.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Infra.Data.Connection
{
    public abstract class RepositoryHandler : IRepositoryHandler
    {
        private DbContextOptions<MercadoDbContext> _options { get; }

        public RepositoryHandler(DbContextOptions<MercadoDbContext> options)
        {
            _options = options;
        }
        
        public async Task<T> Create<T>(T entity) where T : class
        {
            using (var context = GetNewContext())
            {
                context.Add<T>(entity);
                await SaveChangesAsync(context);

                return entity;
            }
        }
        public async Task<bool> Delete<T>(T entity) where T : class
        {
            using (var context = GetNewContext())
            {
                context.Remove<T>(entity);
                return await SaveChangesAsync(context);
            }
        }
        public void DeleteRange<T>(T[] models) where T : class
        {
            using (var context = GetNewContext())
            {
                context.RemoveRange(models);
            }
        }
        public async Task<bool> Update<T>(T entity) where T : class
        {
            using (var context = GetNewContext())
            {
                context.Update<T>(entity);
                return await SaveChangesAsync(context);
            }
        }

        private MercadoDbContext GetNewContext()
        {
            return new MercadoDbContext(_options);
        }
        private async Task<bool> SaveChangesAsync<Context>(Context currentContext) where Context : class
        {
            var context = currentContext is MercadoDbContext ? 
                currentContext as MercadoDbContext :
                throw new InvalidOperationException();

            var create = (await context!.SaveChangesAsync()) > 0;
            return create;
        }
        internal async Task<TValue> CommandExecuterTeste1<TValue>(Func<MercadoDbContext, TValue> action)
        {
            await using (var context = GetNewContext())
            {
                return action.Invoke(context);
            }
        }
        internal TValue CommandExecuterTeste2<TValue>(Func<MercadoDbContext, TValue> action)
        {
            using (var context = GetNewContext())
            {
                return action.Invoke(context);
            }
        }
    } 

}
