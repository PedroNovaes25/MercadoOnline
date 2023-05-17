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
    public class UserRepository : IUserRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public UserRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<bool> Create(Usuario user)
        {
            return await _generalRepository.Insert(new Usuario[] { user });
        }

        public async Task<bool> Delete(Usuario user)
        {
            return await _generalRepository.Remove(user);
        }

        public async Task<bool> Update(Usuario user)
        {
            return await _generalRepository.Update(user);
        }
        public async Task<Usuario> GetById(int userId)
        {
            return (await _generalRepository.CommandExecuter
            (
                u => u.Usuarios
                .AsNoTracking()
                .Where(u => u.IdUsuario == userId)
                .FirstOrDefaultAsync()
            ))!;
        }
    }
}
