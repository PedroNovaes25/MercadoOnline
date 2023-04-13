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
    public class EnderecoRepository : RepositoryHandler, IEnderecoRepository
    {
        public EnderecoRepository(DbContextOptions<MercadoDbContext> options) : base(options)
        {
        }

        public async Task<bool> Create(Endereco endereco)
        {
            return await Insert(endereco);
        }
        public async Task<bool> Delete(Endereco endereco)
        {
            return await Remove(endereco);
        }
        public async Task<bool> Update(Endereco endereco)
        {
            return await Updates(endereco);
        }
        public async Task<Endereco> GetEnderecoById(int idEndereco)
        {
            return (await CommandExecuterTeste2
            (
                e => e.Enderecos.AsNoTracking()
                .Where(e => e.IdEndereco == idEndereco).FirstOrDefaultAsync()
            ))!;
        }
    }
}
