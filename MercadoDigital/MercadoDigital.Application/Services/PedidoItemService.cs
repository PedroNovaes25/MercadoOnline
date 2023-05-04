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
    public class PedidoItemService : IPedidoItemService
    {
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly IMapper _mapper;

        public PedidoItemService(IPedidoItemRepository pedidoItemRepository, IMapper _mapper)
        {
            _pedidoItemRepository = pedidoItemRepository;
            this._mapper = _mapper;
        }

        public async Task<bool> Create(PedidoItemInputDTO pedidoItemDTO)
        {
            try
            {
                var pedido = _mapper.Map<PedidoItem>(pedidoItemDTO);
                return await _pedidoItemRepository.Create(pedido);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
