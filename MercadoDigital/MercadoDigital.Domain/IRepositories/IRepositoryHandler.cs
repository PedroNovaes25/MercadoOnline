using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IRepositoryHandler
    {
        Task<T> Create<T>(T model) where T : class;
        Task<bool> Delete<T>(T model) where T : class;
        void DeleteRange<T>(T[] models) where T : class;
        Task<bool> Update<T>(T model) where T : class;
    }
}
