using MercadoDigital.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<bool> Create(User user);
        Task<User> GetById(int userId);
        Task<bool> Update(User user);
        Task<bool> Delete(User user);
    }
}
