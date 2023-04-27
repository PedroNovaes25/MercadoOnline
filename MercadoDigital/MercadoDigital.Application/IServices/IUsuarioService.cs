using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface IUsuarioService
    {
        Task<bool> Create(UsuarioInputDTO usuarioDTO);
        Task<UsuarioOutputDTO> GetById(int usuarioId);
        Task<bool> Update(UsuarioInputDTO usuarioDTO, int idUsuario);
        Task<bool> Delete(int idUsuario);
    }
}
