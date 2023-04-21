using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IGeneralRepository<Context>
    {
        Task<Entity> Insert<Entity>(Entity entity) where Entity : class;
        Task<bool> Remove<Entity>(Entity entity) where Entity : class;
        void RemoveRange<Entity>(Entity[] entities) where Entity : class;
        Task<bool> Update<Entity>(Entity model) where Entity : class;
        TValue CommandExecuter<TValue>(Func<Context, TValue> action);
    }
}
