﻿using MercadoDigital.Application.DTO.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoDigital.Application.IServices
{
    public interface IPedidoItemService
    {
        Task<bool> Create(PedidoItemInputDTO pedidoItemDTO);
    }
}
