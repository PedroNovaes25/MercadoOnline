using AutoMapper;
using Lib.Exceptions;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public Task<bool> Create(ProductInputDTO productDTO)
        {
            try
            {
                var product = _mapper.Map<Produto>(productDTO);
                return _productRepository.Create(product);
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> Delete(int productId)
        {
            try
            {
                var product = await _productRepository.GetProductById(productId);
                if (product == null)
                    throw new DataNotFoundException($"The product with the ID '{productId}' was not found.");

                return await _productRepository.Delete(product);
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<ProductOutputDTO>> GetAllProducts()
        {
            try
            {
                var products = await _productRepository.GetAllProducts();
                return _mapper.Map<IEnumerable<ProductOutputDTO>>(products);
            }
            catch (Exception){throw;}
        }

        public async Task<IEnumerable<ProductOutputDTO>> GetAllProductsFromCategoryId(int categoryId)
        {
            try
            {
                var products = await _productRepository.GetAllProductsFromCategoryId(categoryId);
                if (products == null)
                    throw new DataNotFoundException($"The products with the categoryId '{categoryId}' was not found.");

                return _mapper.Map<IEnumerable<ProductOutputDTO>>(products);
            }
            catch (Exception){throw;}
        }

        public async Task<ProductOutputDTO> GetProductById(int productId)
        {
            try
            {
                var product = await _productRepository.GetProductById(productId);
                if (product == null)
                    throw new DataNotFoundException($"The product with the ID '{productId}' was not found.");
                return _mapper.Map<ProductOutputDTO>(product);
            }
            catch (Exception){throw;}
        }

        public async Task<IEnumerable<ProductOutputDTO>> GetProductByName(string name)
        {
            try
            {
                var products = await _productRepository.GetProductByName(name);
                return _mapper.Map<IEnumerable<ProductOutputDTO>>(products);
            }
            catch (Exception){throw;}
        }

        public async Task<bool> Update(ProductInputDTO productDTO, int productId)
        {
            try
            {
                var product = await _productRepository.GetProductById(productId);
                if (product == null)
                    throw new DataNotFoundException($"The product with the ID '{productId}' was not found.");

                _mapper.Map(productDTO, product);

                return await _productRepository.Update(product);
            }
            catch (Exception){throw;}
        }
    }
}
