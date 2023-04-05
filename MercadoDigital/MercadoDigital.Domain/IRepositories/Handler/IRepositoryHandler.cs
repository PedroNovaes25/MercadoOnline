using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories.Handler
{
    public interface IRepositoryHandler
    {
        protected internal Task<T> Insert<T>(T model) where T : class;
        Task<bool> Remove<T>(T model) where T : class;
        void RemoveRange<T>(T[] models) where T : class;
        Task<bool> Updates<T>(T model) where T : class;
    }
}
