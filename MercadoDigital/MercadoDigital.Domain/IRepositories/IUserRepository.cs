using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<bool> Create(Usuario user);
        Task<Usuario> GetById(int userId);
        Task<bool> Update(Usuario user);
        Task<bool> Delete(Usuario user);
    }
}
