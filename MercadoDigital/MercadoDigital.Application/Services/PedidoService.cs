﻿using AutoMapper;
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
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(PedidoInputDTO pedidoDTO)
        {
            try
            {
                var pedido = _mapper.Map<Pedido>(pedidoDTO);
                return await _pedidoRepository.Create(pedido);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<PedidoOutputDTO>> GetAllPedidosByUserId(int userId)
        {
            try
            {
                var pedidos = await _pedidoRepository.GetAllPedidosByUserId(userId);
                if (pedidos == null)
                    throw new InvalidOperationException($"Não foram encontradas pedidos pertencentes ao UserID '{userId}'  .");

                return _mapper.Map<IEnumerable<PedidoOutputDTO>>(pedidos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PedidoOutputDTO> GetPedidosById(int idPedido)
        {
            try
            {
                var pedido = await _pedidoRepository.GetPedidosById(idPedido);
                if (pedido == null)
                    throw new InvalidOperationException($"Não foram encontradas pedidos com ID '{idPedido}'.");

                return _mapper.Map<PedidoOutputDTO>(pedido);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}