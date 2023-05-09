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
    public class EnderecoRepository : IAddressRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public EnderecoRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<bool> Create(Endereco address)
        {
            return await _generalRepository.Insert(address);
        }
        public async Task<bool> Delete(Endereco address)
        {
            return await _generalRepository.Remove(address);
        }
        public async Task<bool> Update(Endereco address)
        {
            return await _generalRepository.Update(address);
        }
        public async Task<Endereco> GetAddressById(int addressId)
        {
            return (await _generalRepository.CommandExecuter
            (
                e => e.Enderecos.AsNoTracking()
                .Where(e => e.IdEndereco == addressId).FirstOrDefaultAsync()
            ))!;
        }
    }
}
