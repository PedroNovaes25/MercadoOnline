using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface IAddressService
    {
        Task<AddressOutputDTO> GetAddressById(int addressId);
        Task<bool> Create(AddressInputDTO addressDTO);
        Task<bool> Update(AddressInputDTO addressDTO, int idAddress);
        Task<bool> Delete(int idAddress);
        Task<IEnumerable<AddressOutputDTO>> GetAddressByUserId(int userId);
    }
}
