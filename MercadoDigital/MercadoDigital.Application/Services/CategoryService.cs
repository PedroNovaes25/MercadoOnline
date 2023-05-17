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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(CategoryInputDTO categoryDTO)
        {
            try
            {
                var category = _mapper.Map<Categoria>(categoryDTO);
                return await _categoryRepository.Create(category);
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> Delete(int categoryId)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryById(categoryId);
                if (category == null)
                    throw new DataNotFoundException($"The category with the ID '{categoryId}' was not found.");

                return await _categoryRepository.Delete(category);
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<CategoryOutputDTO>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategories();
                return _mapper.Map<IEnumerable<CategoryOutputDTO>>(categories);
            }
            catch (Exception) { throw; }
        }

        public async Task<CategoryOutputDTO> GetCategoryById(int categoryId)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryById(categoryId);
                if (category == null)
                    throw new DataNotFoundException($"The category with the ID '{categoryId}' was not found.");

                return _mapper.Map<CategoryOutputDTO>(category);
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<CategoryOutputDTO>> GetCategoryByName(string name)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryByName(name);
                return _mapper.Map<IEnumerable<CategoryOutputDTO>>(category);
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> Update(CategoryInputDTO categoryDTO, int categoryId)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryById(categoryId);
                if (category == null)
                    throw new DataNotFoundException($"ID category '{categoryId}' could not be found.");

                _mapper.Map(categoryDTO, category);

                return await _categoryRepository.Update(category);
            }
            catch (Exception) { throw; }
        }
    }
}
