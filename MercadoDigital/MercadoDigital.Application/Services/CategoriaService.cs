using AutoMapper;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using MercadoDigital.Application.IServices;
using MercadoDigital.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            
        }

        public async Task<bool> Delete(int idCategoria)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoriaOutputDTO>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public async Task<CategoriaOutputDTO> GetCategoryById(int idCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoriaOutputDTO>> GetCategoryByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(CategoriaInputDTO categoriaDTO, int idCategoria)
        {
            throw new NotImplementedException();
        }
    }
}
