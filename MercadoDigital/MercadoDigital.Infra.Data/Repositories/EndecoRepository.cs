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
    public class EndecoRepository : IEnderecoRepository
    {
        private readonly MercadoDbContext _context;

        public EndecoRepository(MercadoDbContext context)
        {
            this._context = context;
        }
        public async Task<Endereco> GetEnderecoById(int idEndereco)
        {
            using (var context = _context)
            {
                return await context.Enderecos.AsNoTracking()
                    .Where(e => e.IdEndereco == idEndereco).FirstAsync();
            }
        }
    }
}
