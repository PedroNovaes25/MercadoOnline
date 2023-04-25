using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using MercadoDigital.Infra.Data.Connection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public UsuarioRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<bool> Create(Usuario usuario)
        {
            return await _generalRepository.Insert(usuario);
        }

        public async Task<bool> Delete(Usuario usuario)
        {
            return await _generalRepository.Remove(usuario);
        }

        public async Task<bool> Update(Usuario usuario)
        {
            return await _generalRepository.Update(usuario);
        }
        public async Task<Usuario> GetById(int usuarioId)
        {
            return (await _generalRepository.CommandExecuter
            (
                u => u.Usuarios
                .AsNoTracking()
                .Where(u => u.IdUsuario == usuarioId)
                .FirstOrDefaultAsync()
            ))!;
        }
    }
}
