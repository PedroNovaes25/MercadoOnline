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
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _OrderItemRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository OrderItemRepository, IMapper _mapper)
        {
            _OrderItemRepository = OrderItemRepository;
            this._mapper = _mapper;
        }

        public async Task<bool> Create(OrderItemInputDTO[] orderItemDTO)
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
