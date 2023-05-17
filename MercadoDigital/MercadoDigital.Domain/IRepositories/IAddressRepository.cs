using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IAddressRepository
    {
        Task<Endereco> GetAddressById(int addressId);
        Task<bool> Create(Endereco address);
        Task<bool> Update(Endereco address);
        Task<bool> Delete(Endereco address);
        Task<IEnumerable<Endereco>> GetAddressByUserId(int userId);
    }
}
