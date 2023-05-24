using AutoMapper;
using MercadoDigital.Application.Account;
using MercadoDigital.Application.DTO.input.Login;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using MercadoDigital.Application.IServices;
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
        private readonly IAuthenticate _jwtService;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IAuthenticate authenticate, IMapper mapper)
        {
            _userManager = userManager;
            _jwtService = authenticate;
            _mapper = mapper;
        }

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

        public AuthenticationResponseDTO CreateToken(UserOutputDTO userDTO)
        {
            try
            {
                //Talvez tenha que chamar o user diretamente
                var user = _mapper.Map<User>(userDTO);
                var result = _jwtService.CreateToken(user);

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
    }
}
