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
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public EnderecoRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<bool> Create(Endereco endereco)
        {
            return await _generalRepository.Insert(endereco);
        }
        public async Task<bool> Delete(Endereco endereco)
        {
            return await _generalRepository.Remove(endereco);
        }
        public async Task<bool> Update(Endereco endereco)
        {
            return await _generalRepository.Update(endereco);
        }
        public async Task<Endereco> GetEnderecoById(int idEndereco)
        {
            return (await _generalRepository.CommandExecuter
            (
                e => e.Enderecos.AsNoTracking()
                .Where(e => e.IdEndereco == idEndereco).FirstOrDefaultAsync()
            ))!;
        }
    }
}
