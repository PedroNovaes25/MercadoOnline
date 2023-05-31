using MercadoDigital.Application.Account;
using MercadoDigital.Application.DTO.input.Login;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices.Account
{
    public interface IUserService
    {
        Task<IdentityResult> Create(UserInputDTO userDTO);
        Task<UserOutputDTO> GetUserBy(string username);
        Task<bool> CheckPasswordAsync(string username, string password);
        Task<AuthenticationResponseDTO> CreateToken(UserOutputDTO userDTO);

        Task<bool> AssignRolesToUser(string email, string roleName);
        Task<IEnumerable<string>> GetUserRoles(string email);
        Task<bool> RemoveUserFromRole(string email, string roleName);
    }
}
