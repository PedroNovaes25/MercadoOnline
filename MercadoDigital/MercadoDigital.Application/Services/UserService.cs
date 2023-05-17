using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using MercadoDigital.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.Services
{
    public class UserService : IUserService
    {
        public Task<bool> Create(UserInputDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserOutputDTO> GetById(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UserInputDTO userDTO, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
