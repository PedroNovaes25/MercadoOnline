using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IEnderecoRepository
    {
        Task<Endereco> GetEnderecoById(int idEndereco);
        Task<bool> Create(Endereco endereco);
        Task<bool> Update(Endereco endereco);
        Task<bool> Delete(Endereco endereco);

    }
}
