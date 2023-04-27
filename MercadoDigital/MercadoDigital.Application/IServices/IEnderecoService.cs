using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface IEnderecoService
    {
        Task<EnderecoOutputDTO> GetEnderecoById(int idEndereco);
        Task<bool> Create(EnderecoInputDTO enderecoDTO);
        Task<bool> Update(EnderecoInputDTO enderecoDTO, int idEndereco);
        Task<bool> Delete(int idEndereco);
    }
}
