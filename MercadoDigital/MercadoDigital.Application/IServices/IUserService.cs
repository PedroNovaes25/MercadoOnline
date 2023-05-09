using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface IUserService
    {
        Task<bool> Create(UserInputDTO userDTO);
        Task<UserOutputDTO> GetById(int userId);
        Task<bool> Update(UserInputDTO userDTO, int userId);
        Task<bool> Delete(int userId);
    }
}
