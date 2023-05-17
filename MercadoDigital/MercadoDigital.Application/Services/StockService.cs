using AutoMapper;
using Lib.Exceptions;
using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.DTO.Output;
using MercadoDigital.Application.IServices;
using MercadoDigital.Domain.Entities;
using MercadoDigital.Domain.IRepositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StockService(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(StockInputDTO stockDTO)
        {
            try
            {
                var stock = _mapper.Map<Estoque>(stockDTO);
                return await _stockRepository.CreateOrUpdate(stock);
            }
            catch (Exception) {throw;}
        }

        public async Task<bool> Delete(int stockId)
        {
            try
            {
                var stock = await _stockRepository.GetStockById(stockId);
                if (stock == null)
                    throw new DataNotFoundException($"The stock with the ID '{stockId}' was not found.");

                return await _stockRepository.Delete
                (
                    _mapper.Map<Estoque>(stock)
                );
            }
            catch(Exception){throw;}
        }

        public async Task<bool> Update(StockInputDTO stockDTO, int stockId)
        {
            try
            {
                var stockAndProduct = await _stockRepository.GetStockById(stockId);
                if (stockAndProduct == null)
                    throw new DataNotFoundException($"The stock with the ID '{stockId}' was not found.");

                var stock = _mapper.Map<Estoque>(stockAndProduct);
                _mapper.Map(stockDTO, stock);

                return await _stockRepository.CreateOrUpdate(stock);
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<StockProductOutputDTO>> GetAllStock()
        {
            try
            {
                var stocks = await _stockRepository.GetAllStock();
                return _mapper.Map<IEnumerable<StockProductOutputDTO>>(stocks);
            }
            catch(Exception){throw;}
        }

        public async Task<StockProductOutputDTO> GetStockById(int stockId)
        {
            try
            {
                var stock = await _stockRepository.GetStockById(stockId);
                if (stock == null)
                    throw new DataNotFoundException($"The stock with the ID '{stockId}' was not found.");

                return _mapper.Map<StockProductOutputDTO>(stock);
            }
            catch(Exception){throw;}
        }

        public async Task<StockProductOutputDTO> GetStockByProductId(int productId)
        {
            try
            {
                var stock = await _stockRepository.GetStockByProductId(productId);
                if (stock == null)
                    throw new DataNotFoundException($"The stock with the productId '{productId}' was not found.");

                return _mapper.Map<StockProductOutputDTO>(stock);
            }
            catch(Exception){throw;}
        }
    }
}
