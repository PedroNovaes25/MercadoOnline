using AutoMapper;
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
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(CategoriaInputDTO categoriaDTO)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(categoriaDTO);
                return await _categoriaRepository.Create(categoria);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(int idCategoria)
        {
            try
            {
                var categoria = await _categoriaRepository.GetCategoryById(idCategoria);
                if (categoria == null)
                    throw new InvalidOperationException($"A categoria com o ID '{idCategoria}' não foi encontrado.");

                return await _categoriaRepository.Delete(categoria);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<CategoriaOutputDTO>> GetAllCategories()
        {
            try
            {
                var categorias = await _categoriaRepository.GetAllCategories();
                if (categorias == null)
                    throw new InvalidOperationException($"Não foram encontradas categorias.");

                return _mapper.Map<IEnumerable<CategoriaOutputDTO>>(categorias);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task<CategoriaOutputDTO> GetCategoryById(int idCategory)
        {
            try
            {
                var categoria = await _categoriaRepository.GetCategoryById(idCategory);
                if (categoria == null)
                    throw new InvalidOperationException($"Não foi encontrado categoria de ID '{idCategory}'.");

                return _mapper.Map<CategoriaOutputDTO>(categoria);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<CategoriaOutputDTO>> GetCategoryByName(string name)
        {
            try
            {
                var categoria = await _categoriaRepository.GetCategoryByName(name);
                if (categoria == null)
                    throw new InvalidOperationException($"Não foram encontradas categorias com nome '{name}'.");

                return _mapper.Map<IEnumerable<CategoriaOutputDTO>>(categoria);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(CategoriaInputDTO categoriaDTO, int idCategoria)
        {
            try
            {
                var categoria = await _categoriaRepository.GetCategoryById(idCategoria);
                if (categoria == null)
                    throw new InvalidOperationException($"Não foi encontrado categoria de ID '{idCategoria}'.");

                categoriaDTO.Nome = categoria.Nome;
                _mapper.Map(categoriaDTO, categoria);

                return await _categoriaRepository.Update(categoria);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
