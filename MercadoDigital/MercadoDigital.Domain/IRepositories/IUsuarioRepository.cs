using MercadoDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Create(Usuario usuario);
        Task<Usuario> GetById(int usuarioId);
        Task<bool> Update(Usuario usuario);
        Task<bool> Delete(Usuario usuario);
    }
}
