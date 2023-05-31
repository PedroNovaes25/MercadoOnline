using AutoMapper;
using Lib.Exceptions;
using MercadoDigital.Application.Account;
using MercadoDigital.Application.DTO.input.Login;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using MercadoDigital.Application.IServices.Account;
using MercadoDigital.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.Services.Account
{
    public class UserService : IUserService 
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        #region About Register
        public async Task<bool> CheckPasswordAsync(string username, string password)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
                return isPasswordValid;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IdentityResult> Create(UserInputDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);

                var result = await _userManager.CreateAsync(user, userDTO.Password);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AuthenticationResponseDTO> CreateToken(UserOutputDTO userDTO)
        {
            try
            {
                //Talvez tenha que chamar o user diretamente
                var user = _mapper.Map<User>(userDTO);
                var userRoles = (await _userManager.GetRolesAsync(user)).ToList();
                var result = _tokenService.CreateToken(userDTO, userRoles);

                Type type = result.GetType();
                var properties = type.GetProperties();


                if (!(properties[0].Name == nameof(AuthenticationResponseDTO.Token) && properties[1].Name == nameof(AuthenticationResponseDTO.Expiration)))
                    throw new ArgumentException("Unable to obtain authentication");
             
                return new AuthenticationResponseDTO()
                {
                    Token = properties[0].GetValue(result).ToString(),
                    Expiration = (DateTime)properties[1].GetValue(result)

                };
            }
            catch (Exception)
            {
                throw;
            }
       
        }

        public async Task<UserOutputDTO> GetUserBy(string username)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                return _mapper.Map<UserOutputDTO>(user);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region About authorization
        
        public async Task<bool> AssignRolesToUser(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new DataNotFoundException("Unregistered user email.");

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

        public async Task<IEnumerable<string>> GetUserRoles(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new DataNotFoundException("Unregistered user email.");
            return (await _userManager.GetRolesAsync(user)).ToList();
        }
        
        public async Task<bool> RemoveUserFromRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new DataNotFoundException("Unregistered user email.");

            return (await _userManager.RemoveFromRoleAsync(user, roleName)).Succeeded;
        }

        #endregion
    }
}
