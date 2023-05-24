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
    public class OrderItemsService : IOrderItemsService
    {
        private readonly IOrderItemRepository _OrderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemsService(IOrderItemRepository OrderItemRepository, IMapper _mapper)
        {
            _OrderItemRepository = OrderItemRepository;
            this._mapper = _mapper;
        }

        public async Task<bool> Create(OrderItemsInputDTO[] orderItemDTO)
        {
            try
            {
                var order = _mapper.Map<PedidoItem[]>(orderItemDTO);
                return await _OrderItemRepository.Create(order);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
