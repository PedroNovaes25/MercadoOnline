using MercadoDigital.Domain.Entities.Identity;
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

        public async Task<bool> Create(User user)
        {
            return await _generalRepository.Insert(new User[] { user });
        }

        public async Task<bool> Delete(User user)
        {
            return await _generalRepository.Remove(user);
        }

        public async Task<bool> Update(User user)
        {
            return await _generalRepository.Update(user);
        }
        public async Task<User> GetById(int userId)
        {
            return (await _generalRepository.CommandExecuter
            (
                u => u.Users
                .AsNoTracking()
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync()
            ))!;
        }
    }
}
