using AutoMapper;
using Lib.Exceptions;
using MercadoDigital.Application.IServices.Account;
using MercadoDigital.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.Services.Account
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<Role> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            try
            {
                var roles = await _roleManager.Roles.ToListAsync();

                //TO DO avaliar se crio DTO
                return roles;
            }
            catch (Exception)
            {
                throw;
            }
            

        }
   
        public async Task<bool> CreateRole(string roleName)
        {
            try
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (roleExist) throw new InvalidOperationException($"role '{roleName}' already exists");

                var role = new Role();
                role.Name = roleName;
                var result = await _roleManager.CreateAsync(role);
                return result.Succeeded;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteRole(string roleName)
        {
            try
            {
                var role = await _roleManager.Roles.Where(r => r.Name == roleName).FirstOrDefaultAsync();
                if (role == null) throw new DataNotFoundException($"role '{roleName}' does not exist");

                var result = await _roleManager.DeleteAsync(role);
                return result.Succeeded;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
