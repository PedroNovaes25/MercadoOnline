using MercadoDigital.Application.DTO.Input;
using MercadoDigital.Application.IServices;
using MercadoDigital.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MercadoDigital.API.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsService _orderItemService;

        public OrderItemsController(IOrderItemsService ordertemService)
        {
            _orderItemService = ordertemService;
        }

        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> CreateItemOrder(OrderItemsInputDTO[] ordersItemDTO)
        {
            try
            {
                 var orderCreated = await _orderItemService.Create(ordersItemDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating record");
            }
        }
    }
}
