using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IGeralRepository
    {
        Task<T> Create<T>(T entity) where T : class;
        Task<bool> Update<T>(T entity) where T : class;
        Task<bool> Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entities) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
