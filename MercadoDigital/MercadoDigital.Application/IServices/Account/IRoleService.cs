using MercadoDigital.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices.Account
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<bool> CreateRole(string roleName);
        Task<bool> DeleteRole(string roleName);
    }
}
