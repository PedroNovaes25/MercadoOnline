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
    public class CategoryProductRepository : ICategoryProductRepository
    {
        private readonly IGeneralRepository<MercadoDbContext> _generalRepository;

        public CategoryProductRepository(IGeneralRepository<MercadoDbContext> generalRepository)
        {
            _generalRepository = generalRepository;
        }

        public async Task<bool> Create(CategoriaProduto[] categoriesProduct)
        {
            return await _generalRepository.Insert(categoriesProduct);
        }
    }
}
