using AutoMapper;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.IServices;
using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.Services
{
    public class CategoryProductService : ICategoryProductService
    {
        private readonly ICategoryProductRepository _categoryProductRepository;
        private readonly IMapper _mapper;

        public CategoryProductService(ICategoryProductRepository geralRepository, IMapper mapper)
        {
            _categoryProductRepository = geralRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(CategoryProductInputDTO[] categoriesProductsDTO)
        {
            try
            {
                var categoriesProducts = _mapper.Map<CategoriaProduto[]>(categoriesProductsDTO);
                return await _categoryProductRepository.Create(categoriesProducts); 

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
