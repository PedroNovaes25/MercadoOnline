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
    public class UsuarioRepository : RepositoryHandler, IUsuarioRepository
    {
        public UsuarioRepository(DbContextOptions<MercadoDbContext> options) : base(options)
        {
        }

        public async Task<Usuario> Create(Usuario usuario)
        {
            return await Insert(usuario);
        }

        public async Task<bool> Delete(Usuario usuario)
        {
            return await Remove(usuario);
        }

        public async Task<bool> Update(Usuario usuario)
        {
            return await Updates(usuario);
        }
        public async Task<Usuario> GetById(int usuarioId)
        {
            return (await CommandExecuterTeste2
            (
                u => u.Usuarios
                .AsNoTracking()
                .Where(u => u.IdUsuario == usuarioId)
                .FirstOrDefaultAsync()
            ))!;
        }
    }
}
