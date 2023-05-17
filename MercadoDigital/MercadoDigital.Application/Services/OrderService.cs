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
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository OrderRepository, IMapper mapper)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(OrderInputDTO orderDTO)
        {
            try
            {
                var order = _mapper.Map<Pedido>(orderDTO);
                return await _OrderRepository.Create(order);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<OrderOutputDTO>> GetAllOdersByUserId(int userId)
        {
            try
            {
                var orders = await _OrderRepository.GetAllOrdersByUserId(userId);
                if (orders == null)
                    throw new DataNotFoundException($"The orders with the ID '{userId}' was not found.");
                return _mapper.Map<IEnumerable<OrderOutputDTO>>(orders);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<OrderOutputDTO> GetOdersById(int orderId)
        {
            try
            {
                var orders = await _OrderRepository.GetOrdersById(orderId);
                if (orders == null)
                    throw new DataNotFoundException($"The orders with the ID '{orderId}' was not found.");

                return _mapper.Map<OrderOutputDTO>(orders);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
